using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace DouYinData.Util
{
    /// <summary>
    /// 快捷验证方法
    /// </summary>
    public static class CheckHelper
    {
        /// <summary>
        /// 验证字符是否为空
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns>true:空 false:非空</returns>
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }
        /// <summary>
        /// 验证StringBuilder是否为空
        /// </summary>
        /// <param name="str">StringBuilder</param>
        /// <returns>true:空 false:非空</returns>
        public static bool IsNullOrEmpty(this StringBuilder str)
        {
            return ((StringBuilder)str).Length < 1;
        }
        /// <summary>
        /// 验证DataRow是否为空
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="ColumnName">列名</param>
        /// <returns>true:空 false:非空</returns>
        public static bool IsNullOrEmpty(this DataRow dr, string ColumnName)
        {
            return (dr == null || dr.IsNull(ColumnName) || dr[ColumnName].ToString().IsNullOrEmpty());
        }
        /// <summary>
        /// 验证枚举是否为空
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
            {
                return true;
            }
            var collection = enumerable as ICollection<T>;
            if (collection != null)
            {
                return collection.Count < 1;
            }
            return !enumerable.Any();
        }

        /// <summary>
        /// 判断是否中文字符串
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static bool IsChinese(this string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            return new Regex("^[一-龥]+$", RegexOptions.None).IsMatch(s);
        }

        /// <summary>
        /// 判断字符串内是否有中文
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static bool IsBearWithChinese(this string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            return new Regex("[一-龥]+", RegexOptions.None).IsMatch(s);
        }

        /// <summary>
        /// 验证字符串是否纯数字
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static bool IsNumeric(this string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            return new Regex("^[0-9]*$", RegexOptions.None).IsMatch(s);
        }

        /// <summary>
        /// 验证字符串是否布尔值
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static bool IsBoolean(this string s)
        {
            if (IsNumeric(s))
            {
                return ((int.Parse(s) == 0) || (int.Parse(s) == 1));
            }
            bool result = false;
            return bool.TryParse(s, out result);
        }

        /// <summary>
        /// 验证字符串是否小数
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static bool IsDecimal(this string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            return new Regex(@"^(-?\d+)(\.\d+)?$", RegexOptions.None).IsMatch(s);
        }

        /// <summary>
        /// 验证字符串是否日期
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static bool IsDateTime(this string s)
        {
            DateTime minValue = DateTime.MinValue;
            return DateTime.TryParse(s, out minValue);
        }

        /// <summary>
        /// 验证字符串是否有效银行卡号
        /// </summary>
        /// <param name="cardNo">字符串</param>
        /// <returns></returns>
        public static bool IsCreditCard(this string cardNo)
        {
            if (string.IsNullOrEmpty(cardNo)) return false;
            if (!IsNumeric(cardNo)) return false;
            if ((cardNo.Length != 15) && (cardNo.Length != 0x10)) return false;
            int num = 2;
            int num2 = 0;
            int num3 = 0;
            string str = string.Empty;
            str = cardNo;
            if (cardNo.Length == 15) str = "0" + cardNo;
            char[] chArray = str.ToCharArray();
            for (int i = 0; i < chArray.Length; i++)
            {
                num3 = Convert.ToInt32(chArray[i].ToString()) * num;
                num2 += (num3 > 9) ? (num3 - 9) : num3;
                num = (num == 2) ? 1 : 2;
            }
            return ((num2 % 10) == 0);
        }

        /// <summary>
        /// 验证字符串是否有效传真
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static bool IsFaxNumber(this string s)
        {
            if (((s == null) || (s.Length < 6)) || (s.Length > 0x12))
            {
                return false;
            }
            s = s.Replace("+", string.Empty);
            char[] chArray = s.ToCharArray();
            char ch = chArray[0];
            bool flag = true;
            foreach (char ch2 in chArray)
            {
                if ((ch2 < '0') || (ch2 > '9'))
                {
                    return false;
                }
                if (!ch2.Equals(ch))
                {
                    flag = false;
                }
            }
            return !flag;
        }

        /// <summary>
        /// 验证字符串是否有效邮箱
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static bool IsMail(this string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            return new Regex(@"^[\w.\-]+@[\w.\-]+\.\w+$", RegexOptions.None).IsMatch(s);
        }

        /// <summary>
        /// 验证字符串是否有效手机号
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static bool IsMobile(this string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            return new Regex(@"^((1[3-9]{1})+\d{9})$", RegexOptions.None).IsMatch(s);
        }

        /// <summary>
        /// 验证字符串是否电话号码
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static bool IsPhone(this string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            return new Regex(@"^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$", RegexOptions.None).IsMatch(s);
        }

        /// <summary>
        /// 验证字符串是否QQ号
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static bool IsQQ(this string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            return new Regex("^[1-9][0-9]{4,9}$", RegexOptions.None).IsMatch(s);
        }

        /// <summary>
        /// 验证字符串是否网站
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static bool IsWebsite(this string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            return new Regex(@"^((http|https|ftp)?://)?([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$", RegexOptions.IgnoreCase).IsMatch(s);
        }

        /// <summary>
        /// 验证字符串是否邮编
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static bool IsZipCode(this string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            return new Regex(@"^[1-9]\d{5}(?!\d)$", RegexOptions.None).IsMatch(s);
        }

        /// <summary>
        /// 验证字符串是否有效身份证
        /// </summary>
        /// <param name="idCard">字符串</param>
        /// <returns></returns>
        public static bool IsIDCard(this string idCard)
        {
            if (string.IsNullOrEmpty(idCard))
            {
                return false;
            }
            bool flag = false;
            if (idCard.Length == 0x12)
            {
                flag = ValidIDCard18(idCard);
            }
            if (idCard.Length == 15)
            {
                flag = ValidIDCard15(idCard);
            }
            return flag;
        }

        /// <summary>
        /// 验证15位身份证
        /// </summary>
        /// <param name="idCard">字符串</param>
        /// <returns></returns>
        private static bool ValidIDCard15(string idCard)
        {
            long result = 0;
            if (!(long.TryParse(idCard, out result) && (result >= Math.Pow(10.0, 14.0))))
            {
                return false;
            }
            string str = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (str.IndexOf(idCard.Remove(2)) == -1)
            {
                return false;
            }
            string s = idCard.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (!DateTime.TryParse(s, out time))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 验证18位身份证
        /// </summary>
        /// <param name="idCard">字符串</param>
        /// <returns></returns>
        private static bool ValidIDCard18(string idCard)
        {
            long result = 0;
            if (!((long.TryParse(idCard.Remove(0x11), out result) && (result >= Math.Pow(10.0, 16.0))) && long.TryParse(idCard.Replace('x', '0').Replace('X', '0'), out result)))
            {
                return false;
            }
            string str = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (str.IndexOf(idCard.Remove(2)) == -1)
            {
                return false;
            }
            string s = idCard.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (!DateTime.TryParse(s, out time))
            {
                return false;
            }
            string[] strArray = "1,0,x,9,8,7,6,5,4,3,2".Split(new char[] { ',' });
            string[] strArray2 = "7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2".Split(new char[] { ',' });
            char[] chArray = idCard.Remove(0x11).ToCharArray();
            int a = 0;
            for (int i = 0; i < 0x11; i++)
            {
                a += int.Parse(strArray2[i]) * int.Parse(chArray[i].ToString());
            }
            int num4 = -1;
            Math.DivRem(a, 11, out num4);
            if (strArray[num4] != idCard.Substring(0x11, 1).ToLower())
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 表字段变动差异结果比较
        /// </summary>
        /// <typeparam name="T">表类型</typeparam>
        /// <typeparam name="I">表对应field枚举类型</typeparam>
        /// <param name="c1">数据源</param>
        /// <param name="c2">新数据</param>
        /// <returns></returns>
        public static DifferenceInfos IsHaveDifferen<T, I>(T c1, T c2)
        {
            try
            {
                var Types = c1.GetType();//获得类型  
                var Typed = c2.GetType();//获得类型  
                var allName = typeof(I);
                List<DifferenceInfo> list = new List<DifferenceInfo>();//结果list
                string str = string.Empty;
                foreach (PropertyInfo sp in Types.GetProperties())//获得类型的属性字段  
                {
                    foreach (PropertyInfo dp in Typed.GetProperties())
                    {
                        if (dp.Name == sp.Name)//判断属性名是否相同  
                        {
                            var s = sp.GetValue(c1, null);
                            string ss = s == null ? null : s.ToString();
                            var d = sp.GetValue(c2, null);
                            string dd = d == null ? null : d.ToString();
                            if (ss != dd)
                            {
                                var model = new DifferenceInfo();
                                model.FieldName = dp.Name;
                                model.ValueOriginal = ss;
                                model.ValueFlush = dd;
                                foreach (string Name in Enum.GetNames(allName))
                                {
                                    if (Name == model.FieldName)
                                    {
                                        var pick = (I)Enum.Parse(allName, Name);
                                        model.Describe = ConvertHelperExtend.PackEnumValue(pick, allName);
                                        //model.Sentence = $"{model.Describe}: {ss}=>{dd};";
                                        str += model.Sentence;
                                        break;
                                    }
                                }
                                list.Add(model);
                            }
                            break;
                        }
                    }
                }
                return new DifferenceInfos { Differences = list, DifferenceSentence = str };
            }
            catch
            {
                return null;
            }
        }
    }
    /// <summary>
    /// 比较差异结果
    /// </summary>
    public class DifferenceInfos
    {
        /// <summary>
        /// 差异信息
        /// </summary>
        public List<DifferenceInfo> Differences { get; set; }
        /// <summary>
        /// 总差异描述
        /// </summary>
        public string DifferenceSentence { get; set; }
    }
    /// <summary>
    /// 差异信息集合
    /// </summary>
    public class DifferenceInfo
    {
        /// <summary>
        /// 差异字段名
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// 差异字段枚举描述
        /// </summary>
        public string Describe { get; set; }
        /// <summary>
        /// 差异字段值（原始）
        /// </summary>
        public string ValueOriginal { get; set; }
        /// <summary>
        /// 差异字段值（新）
        /// </summary>
        public string ValueFlush { get; set; }
        /// <summary>
        /// 差异文案展示
        /// </summary>
        public string Sentence { get; set; }
    }
}