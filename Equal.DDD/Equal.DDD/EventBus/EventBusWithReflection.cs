using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equal.DDD.EventBus
{
    public class EventBusWithReflection
    {
        /// <summary>
        /// 单例
        /// </summary>
        public static EventBusWithReflection Default => new EventBusWithReflection();
    }
}
