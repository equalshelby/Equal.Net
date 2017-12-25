using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

using Castle.Windsor;
using Castle.MicroKernel.Registration;

namespace Equal.DDD
{
    /// <summary>
    /// 事件总线
    /// </summary>
    public class EventBus : IEventBus
    {
        //public static EventBus Default => new EventBus();

        /// <summary>
        /// 默认事件总线实例
        /// </summary>
        public static EventBus Default { get; private set; }

        static EventBus()
        {
            Default = new EventBus();
        }

        /// <summary>
        /// Castle Windsor容器
        /// </summary>
        public IWindsorContainer IocContainer { get; private set; }

        /// <summary>
        /// 事件源对应事件处理器字典，线程安全集合
        /// </summary>
        private readonly ConcurrentDictionary<Type, List<Type>> _eventAndHandlerMapping;

        private static object _lock = new object();

        /// <summary>
        /// 构造函数
        /// </summary>
        public EventBus()
        {
            //IocContainer = new WindsorContainer();
            IocContainer = DDD.IocContainer.GetContainer();
            _eventAndHandlerMapping = new ConcurrentDictionary<Type, List<Type>>();
        }

        /// <summary>
        /// 事件源对应事件处理器字典中指定事件源的事件处理器列表
        /// </summary>
        /// <param name="eventType"></param>
        /// <returns></returns>
        private List<Type> GetOrAddEventAndHandlerMapping(Type eventType)
        {
            return _eventAndHandlerMapping.GetOrAdd(eventType, type => new List<Type>());
        }

        /// <summary>
        /// 注册指定的事件处理器
        /// </summary>
        /// <param name="eventType">事件源类型</param>
        /// <param name="handlerType">事件处理类型</param>
        public void Register(Type eventType, Type handlerType)
        {
            //搜索具有指定名称的接口
            var handlerInterface = handlerType.GetInterface("IEventHandler`1");
            //若IocContainer不包含该组件，则注册事件处理器
            if (!IocContainer.Kernel.HasComponent(handlerInterface))
                IocContainer.Register(Component.For(handlerInterface, handlerType));

            lock (_lock)
                GetOrAddEventAndHandlerMapping(eventType).Add(handlerType);
        }

        /// <summary>
        /// 注册事件处理器
        /// </summary>
        /// <typeparam name="TEventData">事件源类型</typeparam>
        /// <param name="eventHandler">事件处理类型</param>
        public void Register<TEventData>(IEventHandler eventHandler)
        {
            Register(typeof(TEventData), eventHandler.GetType());
        }

        /// <summary>
        /// 注册Action事件处理器(Action委托)
        /// </summary>
        /// <typeparam name="TEventData"></typeparam>
        /// <param name="action"></param>
        public void Register<TEventData>(Action<TEventData> action) where TEventData : IEventData
        {
            var actionHandler = new ActionEventHandler<TEventData>(action);

            IocContainer.Register(
                Component.For<IEventHandler<TEventData>>().UsingFactoryMethod(() => actionHandler)
                );

            Register<TEventData>(actionHandler);
        }

        /// <summary>
        /// 注册指定程序集中实现的事件处理器
        /// </summary>
        /// <param name="assembly"></param>
        public void RegisterAllEventHandlerFromAssembly(Assembly assembly)
        {
            //将指定程序集中的IEventHandler注册到IoC容器
            IocContainer.Register(Classes.FromAssembly(assembly)
                    .BasedOn(typeof(IEventHandler<>))
                    .WithService
                    .Base());

            //从IoC容器中获取所有IEventHandler
            var handlers = IocContainer.Kernel.GetAssignableHandlers(typeof(IEventHandler));
            foreach (var handler in handlers)
            {
                //遍历所有的IEventHandler<T>
                var interfaces = handler.ComponentModel.Implementation.GetInterfaces();
                foreach (var @interface in interfaces)
                {
                    if (!typeof(IEventHandler).IsAssignableFrom(@interface))
                        continue;

                    //获取泛型参数类型
                    var genericArgs = @interface.GetGenericArguments();
                    if (genericArgs.Length == 1)
                        Register(genericArgs[0], handler.ComponentModel.Implementation);
                }
            }
        }

        /// <summary>
        /// 取消指定事件源的某个已注册事件处理器
        /// </summary>
        /// <typeparam name="TEventData"></typeparam>
        /// <param name="handlerType"></param>
        public void UnRegister<TEventData>(Type handlerType) where TEventData : IEventData
        {
            lock (_lock)
                GetOrAddEventAndHandlerMapping(typeof(TEventData)).RemoveAll(t => t == handlerType);
        }

        /// <summary>
        /// 取消指定事件源的所有已注册事件处理器
        /// </summary>
        /// <typeparam name="TEventData"></typeparam>
        public void UnRegisterAll<TEventData>() where TEventData : IEventData
        {
            lock (_lock)
                GetOrAddEventAndHandlerMapping(typeof(TEventData)).Clear();
        }

        /// <summary>
        /// 触发事件处理
        /// </summary>
        /// <typeparam name="TEventData"></typeparam>
        /// <param name="eventData"></param>
        public void Trigger<TEventData>(TEventData eventData) where TEventData : IEventData
        {
            //获取事件源注册的所有事件处理器类型
            List<Type> handlerTypes = GetOrAddEventAndHandlerMapping(typeof(TEventData));
            if (handlerTypes != null && handlerTypes.Count > 0)
            {
                foreach (var handlerType in handlerTypes)
                {
                    //从IoC容器中获取所有此事件源的事件处理器实例
                    var handlerInterface = handlerType.GetInterface("IEventHandler`1");
                    var eventHandlers = IocContainer.ResolveAll(handlerInterface);

                    //当类型与映射字典中事件处理器类型一致时，触发事件
                    foreach (var eventHandler in eventHandlers)
                    {
                        if (eventHandler.GetType() == handlerType)
                        {
                            var handler = eventHandler as IEventHandler<TEventData>;
                            handler?.HandlerEvent(eventData);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 触发事件处理，指定的事件处理器
        /// </summary>
        /// <typeparam name="TEventData"></typeparam>
        /// <param name="eventHandlerType"></param>
        /// <param name="eventData"></param>
        public void Trigger<TEventData>(Type eventHandlerType, TEventData eventData) where TEventData : IEventData
        {
            //从IoC容器中获取所有此事件源的事件处理器实例
            var handlerInterface = eventHandlerType.GetInterface("IEventHandler`1");
            var eventHandlers = IocContainer.ResolveAll(handlerInterface);
            //当类型与映射字典中事件处理器类型一致时，触发事件
            foreach (var eventHandler in eventHandlers)
            {
                if (eventHandler.GetType() == eventHandlerType)
                {
                    var handler = eventHandler as IEventHandler<TEventData>;
                    handler?.HandlerEvent(eventData);
                }
            }
        }

        /// <summary>
        /// 触发异步事件处理
        /// </summary>
        /// <typeparam name="TEventData"></typeparam>
        /// <param name="eventData"></param>
        /// <returns></returns>
        public Task TriggerAsync<TEventData>(TEventData eventData) where TEventData : IEventData
        {
            return Task.Run(() => Trigger<TEventData>(eventData));
        }

        /// <summary>
        /// 触发异步事件处理，指定事件处理器
        /// </summary>
        /// <typeparam name="TEventData"></typeparam>
        /// <param name="eventHandlerType"></param>
        /// <param name="eventData"></param>
        /// <returns></returns>
        public Task TriggerAsycn<TEventData>(Type eventHandlerType, TEventData eventData) where TEventData : IEventData
        {
            return Task.Run(() => Trigger(eventHandlerType, eventData));
        }

    }
}
