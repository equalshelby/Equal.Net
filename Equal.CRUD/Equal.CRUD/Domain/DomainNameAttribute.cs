using System;

namespace Equal.CRUD.Domain
{
    /// <summary>
    /// DomainName自定义特性(描述性声明)
    /// </summary>
    public class DomainNameAttribute : Attribute
    {
        /// <summary>
        /// 领域对象名称
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="value"></param>
        public DomainNameAttribute(string value)
        {
            Value = value;
        }
    }
}
