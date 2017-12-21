using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
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
        /// 注册事件处理器
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

            //添加事件源对应事件处理器字典中指定事件源的事件处理器列表
            lock (_lock)
                GetOrAddEventAndHandlerMapping(eventType).Add(handlerType);
        }

        /// <summary>
        /// 注册事件处理器
        /// </summary>
        /// <typeparam name="TEventData"></typeparam>
        /// <param name="eventHandler"></param>
        public void Register<TEventData>(IEventHandler eventHandler)
        {
            throw new NotImplementedException();
        }

        public void Register<TEventData>(Action<TEventData> action) where TEventData : IEventData
        {
            throw new NotImplementedException();
        }

        public void RegisterAllEventHandlerFromAssembly(Assembly assembly)
        {
            throw new NotImplementedException();
        }

        public void Trigger<TEventData>(TEventData eventData) where TEventData : IEventData
        {
            throw new NotImplementedException();
        }

        public void Trigger<TEventData>(Type eventHandlerType, TEventData eventData) where TEventData : IEventData
        {
            throw new NotImplementedException();
        }

        public Task TriggerAsycn<TEventData>(Type eventHandlerType, TEventData eventData) where TEventData : IEventData
        {
            throw new NotImplementedException();
        }

        public Task TriggerAsync<TEventData>(TEventData eventData) where TEventData : IEventData
        {
            throw new NotImplementedException();
        }

        public void UnRegisterAll<TEventData>() where TEventData : IEventData
        {
            throw new NotImplementedException();
        }
    }
}
