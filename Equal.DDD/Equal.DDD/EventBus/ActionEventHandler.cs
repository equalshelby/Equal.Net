using System;

namespace Equal.DDD
{
    /// <summary>
    /// 支持Action的事件处理器（委托-Action）
    /// </summary>
    /// <typeparam name="TEventData">事件源</typeparam>
    internal class ActionEventHandler<TEventData> : IEventHandler where TEventData : IEventData
    {
        /// <summary>
        /// 定义Action的引用，并通过构造函数传参初始化
        /// </summary>
        public Action<TEventData> Action { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="handler"></param>
        public ActionEventHandler(Action<TEventData> handler)
        {
            Action = handler;
        }

        /// <summary>
        /// 事件处理方法
        /// </summary>
        /// <param name="eventData"></param>
        public void HandlerEvent(TEventData eventData)
        {
            Action(eventData);
        }
    }
}
