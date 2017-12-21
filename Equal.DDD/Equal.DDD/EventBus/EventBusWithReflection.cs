using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;

namespace Equal.DDD
{
    /// <summary>
    /// 事件总线，通过反射实现，不建议使用(有性能瓶颈隐患)
    /// </summary>
    public class EventBusWithReflection
    {

        //public static EventBusWithReflection Default => new EventBusWithReflection();

        /// <summary>
        /// 默认事件总线实例
        /// </summary>
        public static EventBusWithReflection Default { get; }

        static EventBusWithReflection()
        {
            Default = new EventBusWithReflection();
        }

        /// <summary>
        /// 事件源对应事件处理器集合字典，线程安全集合
        /// </summary>
        private readonly ConcurrentDictionary<Type, List<Type>> _eventAndHandlerMapping;

        /// <summary>
        /// 构造函数
        /// </summary>
        public EventBusWithReflection()
        {
            _eventAndHandlerMapping = new ConcurrentDictionary<Type, List<Type>>();
            MapEventToHandler();
        }

        /// <summary>
        /// 注册当前应用程序集中所有事件处理器，使用反射
        /// </summary>
        private void MapEventToHandler()
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            if (assembly == null)
                return;

            foreach (var type in assembly.GetTypes())
            {
                //判断是否实现了IEventHandler接口
                if (typeof(IEventHandler).IsAssignableFrom(type))
                {
                    //获取该类实现的泛型接口
                    Type handlerInterface = type.GetInterface("IEventHandler`1");
                    if (handlerInterface != null)
                    {
                        //获取泛型接口指定的参数类型
                        Type eventDataType = handlerInterface.GetGenericArguments()[0];

                        if (_eventAndHandlerMapping.ContainsKey(eventDataType))
                        {
                            List<Type> handlerTypes = _eventAndHandlerMapping[eventDataType];
                            handlerTypes.Add(type);
                            _eventAndHandlerMapping[eventDataType] = handlerTypes;
                        }
                        else
                        {
                            var handlerTypes = new List<Type> { type };
                            _eventAndHandlerMapping[eventDataType] = handlerTypes;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 注册事件处理器
        /// </summary>
        /// <typeparam name="TEventData"></typeparam>
        /// <param name="eventHandler"></param>
        public void Register<TEventData>(Type eventHandler)
        {
            if (_eventAndHandlerMapping.Keys.Contains(typeof(TEventData)))
            {
                List<Type> handlerTypes = _eventAndHandlerMapping[typeof(TEventData)];
                if (!handlerTypes.Contains(eventHandler))
                {
                    handlerTypes.Add(eventHandler);
                    _eventAndHandlerMapping[typeof(TEventData)] = handlerTypes;
                }
            }
            else
                _eventAndHandlerMapping.TryAdd(typeof(TEventData), new List<Type>() { eventHandler });
        }

        /// <summary>
        /// 取消事件注册
        /// </summary>
        /// <typeparam name="TEventData"></typeparam>
        /// <param name="eventHandler"></param>
        public void UnRegister<TEventData>(Type eventHandler)
        {
            List<Type> handlerTypes = _eventAndHandlerMapping[typeof(TEventData)];
            if (handlerTypes.Contains(eventHandler))
            {
                handlerTypes.Remove(eventHandler);
                _eventAndHandlerMapping[typeof(TEventData)] = handlerTypes;
            }
        }

        /// <summary>
        /// 触发事件
        /// </summary>
        /// <typeparam name="TEventData"></typeparam>
        /// <param name="eventData"></param>
        public void Trigger<TEventData>(TEventData eventData) where TEventData : IEventData
        {
            List<Type> handlers = _eventAndHandlerMapping[typeof(TEventData)];

            if (handlers != null && handlers.Count > 0)
            {
                foreach (var handler in handlers)
                {
                    MethodInfo methodInfo = handler.GetMethod("HandleEvent");
                    if (methodInfo != null)
                    {
                        object obj = Activator.CreateInstance(handler);
                        methodInfo.Invoke(obj, new object[] { eventData });
                    }
                }
            }
        }
    }
}
