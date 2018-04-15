using System;

using Equal.CRUD.Domain;

namespace Model.Domain
{
    [Serializable]
    public class KeyValueCondition : ICondition
    {
        #region Key
        /// <summary>
        /// key
        /// </summary>
        public bool ByKey { get; set; }

        private string _key;

        /// <summary>
        /// Key
        /// </summary>
        public string Key
        {
            get { return _key; }
            set { _key = value; ByKey = true; }
        }
        #endregion

        #region AdditionalData
        /// <summary>
        /// AdditionalData
        /// </summary>
        public bool ByAdditionalData { get; set; }

        private string _additionalData;

        /// <summary>
        /// AdditionalData
        /// </summary>
        public string AdditionalData
        {
            get { return _additionalData; }
            set { _additionalData = value; ByAdditionalData = true; }
        }
        #endregion
    }
}
