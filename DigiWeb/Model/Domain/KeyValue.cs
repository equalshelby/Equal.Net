using Equal.CRUD.Domain;
using Equal.Utility;

namespace Model.Domain
{
    /// <summary>
    /// KeyValue存储
    /// </summary>
    public class KeyValue : DomainBase<long>
    {
        public KeyValue()
        {
            Id = SnowFlake.GetNewId();
        }

        /// <summary>
        /// Key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 附加数据
        /// </summary>
        public string AdditionalData { get; set; }
    }
}
