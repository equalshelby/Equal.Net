using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Equal.Utility
{
    /*该扩展方法可download到，根据自己需求修改即可*/

    /// <summary>
    /// String扩展方法
    /// </summary>
    public static class StringExtensionMethod
    {
        /// <summary>
        /// 替换空字符串
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <param name="strReplace">替换字符串</param>
        /// <returns></returns>
        public static string IfNullOrEmpty(this string str, string strReplace)
        {
            if (string.IsNullOrEmpty(str))
                return strReplace;
            return str;
        }

        #region 字符串拆分

        /// <summary>
        /// 将字符串按分隔符拆分成一组数字
        /// </summary>
        /// <param name="str"></param>
        /// <param name="separator">分隔符</param>
        /// <param name="allowRepeat">是否允许重复值</param>
        /// <returns></returns>
        public static IList<int> SplitInt(this string str, string separator, bool allowRepeat = false)
        {
            IList<int> list = new List<int>();
            if (!string.IsNullOrEmpty(str))
            {
                string[] ss = Regex.Split(str, separator);
                foreach (string s in ss)
                {
                    if (string.IsNullOrEmpty(s.Trim()))
                        continue;

                    int i;
                    if (!int.TryParse(s.Trim(), out i))
                        continue;

                    if (!list.Contains(i))
                        list.Add(i);
                    else
                    {
                        if (allowRepeat)
                            list.Add(i);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 将字符串按分隔符拆分
        /// </summary>
        /// <param name="str"></param>
        /// <param name="separator">分隔符</param>
        /// <param name="includeEmpty">是否包含空字符串</param>
        /// <param name="trim">是否清除两端空格</param>
        /// <param name="allowRepeat">是否允许重复值</param>
        /// <returns></returns>
        public static IList<string> SplitString(this string str, string separator, bool includeEmpty = false, bool trim = true, bool allowRepeat = false)
        {
            IList<string> list = new List<string>();
            if (!string.IsNullOrEmpty(str))
            {
                //string[] ss = str.Split(new[] { ',' });
                string[] ss = Regex.Split(str, separator);
                foreach (string s in ss)
                {
                    if (!includeEmpty && string.IsNullOrEmpty(s.Trim()))
                        continue;

                    string temp = s;
                    if (trim)
                        temp = s.Trim();

                    if (!list.Contains(temp))
                        list.Add(temp);
                    else
                    {
                        if (allowRepeat)
                            list.Add(temp);
                    }
                }
            }
            return list;
        }

        #region Substring
        /// <summary>
        /// 取字符串的字节长度，由于是逐字分析，性能较差
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int GetByteLength(this string s)
        {
            int byteLength = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (Convert.ToInt32(s[i]) > 255)
                    byteLength += 2;
                else
                    byteLength++;
            }
            return byteLength;
        }
        #endregion
        #endregion

        #region 解析字符串为int、long、double、float、decimal、DateTime、Enum

        #region Int
        /// <summary>
        /// 解析字符串为Int?
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int? ToInt(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return null;
            int t;
            if (int.TryParse(s.Trim(), out t))
                return t;
            return null;
        }

        /// <summary>
        /// 解析字符串为Int，如无法解析抛出异常
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int ToIntReq(this string s)
        {
            int? i = s.ToInt();
            if (!i.HasValue)
                throw new ArgumentException(string.Format("无法将值“{0}”解析为Int类型。"));
            return i.Value;
        }

        /// <summary>
        /// 解析字符串为Int(默认值为0)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int ToIntOrDefault(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return default(int);//调用int构造函数,构造函数默认值为0

            int i;
            if (int.TryParse(s.Trim(), out i))
                return i;

            return default(int);
        }

        /// <summary>
        /// 解析字符串为Int(自定义默认值)
        /// </summary>
        /// <param name="t"></param>
        /// <param name="defaultValue">自定义默认值</param>
        /// <returns></returns>
        public static int ToIntOrDefault(this string t, int defaultValue)
        {
            if (string.IsNullOrEmpty(t))
                return defaultValue;

            int v;
            if (int.TryParse(t.Trim(), out v))
                return v;
            return defaultValue;
        }
        #endregion

        #region Long(long)
        /// <summary>
        /// 解析字符串为Long?
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static long? ToLong(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return null;
            long i;
            if (long.TryParse(s.Trim(), out i))
                return i;

            return null;
        }

        /// <summary>
        /// 解析字符串为Long，如无法解析抛出异常
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static long ToLongReq(this string s)
        {
            long? i = s.ToLong();
            if (!i.HasValue)
                throw new ArgumentException(string.Format("无法将值“{0}”解析为Long类型。", s));
            return i.Value;
        }

        /// <summary>
        /// 解析字符串为Long(默认值为0)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static long ToLongOrDefault(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return default(long);//调用long构造函数
            long i;
            if (long.TryParse(s.Trim(), out i))
                return i;
            return default(long);
        }

        /// <summary>
        /// 解析字符串为Long(自定义默认值)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue">自定义默认值</param>
        /// <returns></returns>
        public static long ToLongOrDefault(this string s, long defaultValue)
        {
            if (string.IsNullOrEmpty(s))
                return defaultValue;
            long i;
            if (long.TryParse(s.Trim(), out i))
                return i;
            return defaultValue;
        }
        #endregion

        #region Double
        /// <summary>
        /// 解析字符串为double?
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static double? ToDouble(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return null;
            double i;
            if (double.TryParse(s.Trim(), out i))
                return i;
            return null;
        }

        /// <summary>
        /// 解析字符串为double，如无法解析抛出异常
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static double ToDoubleReq(this string s)
        {
            double? i = s.ToDouble();
            if (!i.HasValue)
                throw new ArgumentException(string.Format("无法将值“{0}”解析为double类型。", s));
            return i.Value;
        }

        /// <summary>
        /// 解析字符串为double，如果为空或无法转换，则转换成默认double
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static double ToDoubleOrDefault(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return default(double);
            double i;
            if (double.TryParse(s.Trim(), out i))
                return i;
            return default(double);
        }

        /// <summary>
        /// 解析字符串为double，如果为空或无法转换，则转换成自定义double
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue">自定义</param>
        /// <returns></returns>
        public static double ToDoubleOrDefault(this string s, double defaultValue)
        {
            if (string.IsNullOrEmpty(s))
                return defaultValue;
            double i;
            if (double.TryParse(s.Trim(), out i))
                return i;
            return defaultValue;
        }
        #endregion

        #region Float
        /// <summary>
        /// 解析字符串为Float?
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static float? ToFloat(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return null;
            float i;
            if (float.TryParse(s.Trim(), out i))
                return i;
            return null;
        }

        /// <summary>
        /// 解析字符串为Float，如无法解析抛出异常
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static float ToFloatReq(this string s)
        {
            float? i = s.ToFloat();
            if (!i.HasValue)
                throw new ArgumentException(string.Format("无法将值“{0}”解析为float类型。", s));
            return i.Value;
        }

        /// <summary>
        /// 解析字符串为Float，如果为空或无法转换，则转换成默认Float
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static float ToFloatOrDefault(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return default(float);//调用Float类的构造函数，初始化
            float i;
            if (float.TryParse(s.Trim(), out i))
                return i;
            return default(float);
        }

        /// <summary>
        /// 解析字符串为Float，如果为空或无法转换，则转换成自定义Float
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static float ToFloatOrDefault(this string s, float defaultValue)
        {
            if (string.IsNullOrEmpty(s))
                return defaultValue;
            float i;
            if (float.TryParse(s.Trim(), out i))
                return i;
            return defaultValue;
        }

        #endregion

        #region Decimal
        /// <summary>
        /// 解析字符串为decimal?
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static decimal? ToDecimal(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return null;
            decimal i;
            if (decimal.TryParse(s.Trim(), out i))
                return i;
            return null;
        }

        /// <summary>
        /// 解析字符串为decimal，如无法解析抛出异常
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static decimal ToDecimalReq(this string s)
        {
            decimal? i = s.ToDecimal();
            if (!i.HasValue)
                throw new ArgumentException(string.Format("无法将值“{0}”解析为decimal类型。", s));
            return i.Value;
        }

        /// <summary>
        /// 解析字符串为DecimalOrDefault
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static decimal ToDecimalOrDefault(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return default(decimal);//调用decimal构造函数

            decimal i;
            if (decimal.TryParse(s.Trim(), out i))
                return i;
            return default(decimal);
        }

        /// <summary>
        /// 解析字符串为DecimalOrDefault
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue">自定义默认值</param>
        /// <returns></returns>
        public static decimal ToDecimalOrDefault(this string s, decimal defaultValue)
        {
            if (string.IsNullOrEmpty(s))
                return defaultValue;

            decimal i;
            if (decimal.TryParse(s.Trim(), out i))
                return i;
            return defaultValue;
        }
        #endregion

        #region DateTime
        /// <summary>
        /// 解析字符串为DateTime?
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static DateTime? ToDateTime(this string t)
        {
            if (string.IsNullOrEmpty(t))
                return null;

            DateTime v;
            if (DateTime.TryParse(t.Trim(), out v))
                return v;
            return null;
        }

        /// <summary>
        /// 解析字符串为DateTime，如无法解析抛出异常
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static DateTime ToDateTimeReq(this string t)
        {
            DateTime? d = t.ToDateTime();
            if (!d.HasValue)
                throw new ArgumentException(string.Format("无法将值“{0}”解析为DateTime类型。", t));
            return d.Value;
        }

        /// <summary>
        /// 解析字符串为DateTime
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static DateTime ToDateTimeOrDefault(this string t)
        {
            if (string.IsNullOrEmpty(t))
                return default(DateTime);

            DateTime v;
            if (DateTime.TryParse(t.Trim(), out v))
                return v;
            return default(DateTime);
        }

        /// <summary>
        /// 解析字符串为DateTime
        /// </summary>
        /// <param name="t"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime ToDateTimeOrDefault(this string t, DateTime defaultValue)
        {
            if (string.IsNullOrEmpty(t))
                return defaultValue;

            DateTime v;
            if (DateTime.TryParse(t.Trim(), out v))
                return v;
            return defaultValue;
        }
        #endregion

        #region Bool

        /// <summary>
        /// 解析字符串为bool?
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool? ToBool(this string t)
        {
            if (string.IsNullOrEmpty(t))
                return null;

            bool v;
            if (bool.TryParse(t.Trim(), out v))
                return v;
            return null;
        }

        /// <summary>
        /// 解析字符串为bool，如无法解析抛出异常
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool ToBoolReq(this string t)
        {
            bool? b = t.ToBool();
            if (!b.HasValue)
                throw new ArgumentException(string.Format("无法将值“{0}”解析为bool类型。", t));
            return b.Value;
        }

        /// <summary>
        /// 解析字符串为bool
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool ToBoolOrDefault(this string t)
        {
            if (string.IsNullOrEmpty(t))
                return default(bool);

            bool v;
            if (bool.TryParse(t.Trim(), out v))
                return v;
            return default(bool);
        }

        /// <summary>
        /// 解析字符串为bool
        /// </summary>
        /// <param name="t"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static bool ToBoolOrDefault(this string t, bool defaultValue)
        {
            if (string.IsNullOrEmpty(t))
                return defaultValue;

            bool v;
            if (bool.TryParse(t.Trim(), out v))
                return v;
            return defaultValue;
        }
        #endregion

        #region Enum
        /// <summary>
        /// 解析字符串为Enum，与Enum.Parse不同，不在枚举类定义的值无法解析
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <returns></returns>
        public static T? ToEnum<T>(this string s) where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new NotSupportedException(string.Format("{0}必须为枚举类型。", typeof(T)));
            if (string.IsNullOrEmpty(s))
                return null;
            foreach (T item in Enum.GetValues(typeof(T)))
            {
                if (item.ToString() == s.Trim() || typeof(T).GetField(item.ToString()).GetRawConstantValue().ToString() == s.Trim())
                    return item;
            }
            return null;
        }

        /// <summary>
        /// 解析字符串为Enum，与Enum.Parse不同，未在枚举类定义的值无法解析，如无法解析抛出异常
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <returns></returns>
        public static T ToEnumReq<T>(this string s) where T : struct
        {
            T? t = s.ToEnum<T>();
            if (!t.HasValue)
                throw new ArgumentException(string.Format("无法将值“{0}”解析为“{1}”枚举类型。", t, typeof(T)));
            return t.Value;
        }

        /// <summary>
        /// 解析字符串为Enum，与Enum.Parse不同，未在枚举类定义的值无法解析
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T ToEnumOrDefault<T>(this string s, T defaultValue) where T : struct
        {
            T? t = s.ToEnum<T>();
            if (t.HasValue)
                return t.Value;
            return defaultValue;
        }

        /// <summary>
        /// 解析字符串为Enum，与Enum.Parse不同，未在枚举类定义的值无法解析
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <returns></returns>
        public static T ToEnumOrDefault<T>(this string s) where T : struct
        {
            return s.ToEnumOrDefault<T>(default(T));
        }

        /// <summary>
        /// 根据枚举Text解析为Enum（Text可能重复，此方法返回第一个找到的值）
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static T? ToEnumByText<T>(this string t) where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new NotSupportedException(string.Format("{0}必须为枚举类型。", typeof(T)));

            //if (string.IsNullOrEmpty(t))
            //	return null;

            foreach (T value in Enum.GetValues(typeof(T)))
            {
                var attributes = (EnumTextAttribute[])typeof(T).GetField(value.ToString()).GetCustomAttributes(typeof(EnumTextAttribute), false);
                string text = value.ToString();
                if (attributes.Count() > 0)
                    text = attributes.First().Value;

                if (text == t)
                    return value;
            }
            return null;
        }

        /// <summary>
        /// 根据枚举Text解析为Enum，如找不到抛出异常（Text可能重复，此方法返回第一个找到的值）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static T ToEnumReqByText<T>(this string t) where T : struct
        {
            T? e = t.ToEnum<T>();
            if (!e.HasValue)
                throw new ArgumentException(string.Format("无法找到枚举类型“{1}”文本为“{0}”的值。", t, typeof(T)));
            return e.Value;
        }

        ///// <summary>
        ///// 根据枚举Text解析为Enum
        ///// </summary>
        ///// <param name="t"></param>
        ///// <returns></returns>
        //public static T ToEnumOrDefaultByText<T>(this string t) where T : struct
        //{
        //	return t.ToEnumOrDefault(default(T));
        //}

        /// <summary>
        /// 根据枚举Text解析为Enum（Text可能重复，此方法返回第一个找到的值）
        /// </summary>
        /// <param name="t"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T ToEnumOrDefaultByText<T>(this string t, T defaultValue = default(T)) where T : struct
        {
            T? e = t.ToEnumByText<T>();

            if (e.HasValue)
                return e.Value;

            return defaultValue;
        }
        #endregion

        #endregion
    }
}
