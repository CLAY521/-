using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        public static long GetNextId()
        {
            byte[] bytes = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(bytes, 0).ToString().Substring(0, 15).Tolong();
        }
    }
    /// <summary>
    /// DB object对象的扩展方法
    /// </summary>
    public static class DBObjectMethodHelper
    {
        public static bool isint(this string o)
        {
            int count;
            if (int.TryParse(o, out count))
            {
                return true;
            }
            return false;
        }

        public static bool Tobool(this object o)
        {
            if (o == null || Convert.IsDBNull(o))
                return false;
            return Convert.ToBoolean(o);
        }
        public static short Toshort(this object o)
        {
            if (o == null || Convert.IsDBNull(o))
                return 0;
            return Convert.ToInt16(o);
        }
        public static int Toint(this object o)
        {
            if (o == null || Convert.IsDBNull(o))
                return 0;
            return Convert.ToInt32(o);
        }
        public static double Todouble(this object o)
        {
            if (o == null || Convert.IsDBNull(o))
                return 0;
            return Convert.ToDouble(o);
        }
        public static decimal Todecimal(this object o)
        {
            if (o == null || Convert.IsDBNull(o))
                return 0;
            return Convert.ToDecimal(o);
        }
        public static long Tolong(this object o)
        {
            if (o == null || Convert.IsDBNull(o))
                return 0;
            return Convert.ToInt64(o);
        }
        public static string Tostring(this object o)
        {
            if (o == null || Convert.IsDBNull(o))
                return null;
            return Convert.ToString(o);
        }
        public static DateTime ToDateTime(this object o)
        {
            if (o == null || Convert.IsDBNull(o))
                return new DateTime();
            return Convert.ToDateTime(o);
        }
        public static Byte ToByte(this object o)
        {
            if (o == null || Convert.IsDBNull(o))
                return 0;
            return Convert.ToByte(o);
        }
        public static byte[] ToBytes(this object o)
        {
            if (o == null || Convert.IsDBNull(o))
                return null;
            return (byte[])(o);
        }
    }

    /// <summary>
    /// 类型映射帮助
    /// </summary>
    public static class MapperHelper
    {
        /// <summary>
        /// 拷贝到另一个实体
        /// </summary>
        /// <param name="from">源</param>
        /// <param name="to"></param>
        /// <param name="convertNull">是否转换NULL</param>
        /// <param name="ignore">忽略的字段,全小写</param>
        public static void Copy(object from, object to, bool convertNull = false, string[] ignore = null)
        {
            //利用反射获得类成员
            var fieldFroms = from.GetType().GetProperties();//要修改的值
            var fieldTos = to.GetType().GetProperties();//从数据库取出的值
            int lenTo = fieldTos.Length;//一共有多少字段
            for (int i = 0, l = fieldFroms.Length; i < l; i++)
            {
                var ffrom = fieldFroms[i];
                for (int j = 0; j < lenTo; j++)
                {
                    var fto = fieldTos[j];

                    string toName = fto.Name;
                    if (toName != ffrom.Name) continue;
                    if (ignore != null &&
                        ignore.FirstOrDefault(f => f.Equals(toName, StringComparison.OrdinalIgnoreCase)) != null)
                    {
                        continue;
                    }
                    //if (ignore != null && ignore.Contains(fieldTos[j].Name.ToLower())) continue;
                    if (ffrom.CanRead && fto.CanWrite)
                    {
                        var tmpValue = fieldFroms[i].GetValue(from, null);
                        if (tmpValue == null)
                        {
                            if (convertNull)
                            {
                                fieldTos[j].SetValue(to, tmpValue, null);
                            }
                        }
                        else
                        {
                            fieldTos[j].SetValue(to, tmpValue, null);
                        }
                        break;
                    }
                }
            }
        }


        /// <summary>
        /// 拷贝到另一个实体, 只拷贝fields里的字段
        /// </summary>
        /// <param name="from">源</param>
        /// <param name="to"></param>
        /// <param name="fields">拷贝的字段,全小写</param>
        /// <param name="convertNull">是否转换NULL 默认转换</param>
        public static void CopyNeed(object from, object to, string[] fields, bool convertNull = true)
        {
            //利用反射获得类成员
            var fieldFroms = from.GetType().GetProperties();
            var fieldTos = to.GetType().GetProperties();
            for (var i = 0; i < fields.Length; i++)
            {
                string fName = fields[i];
                var ffrom = fieldFroms.FirstOrDefault(f => fName.Equals(f.Name, StringComparison.OrdinalIgnoreCase));
                if (ffrom == null)
                {
                    break;
                }
                var fto = fieldTos.FirstOrDefault(f => fName.Equals(f.Name, StringComparison.OrdinalIgnoreCase));
                if (fto == null)
                {
                    break;
                }

                if (ffrom.CanRead && fto.CanWrite)
                {
                    var tmpValue = ffrom.GetValue(from, null);
                    if (tmpValue == null)
                    {
                        if (convertNull)
                        {
                            fto.SetValue(to, tmpValue, null);
                        }
                    }
                    else
                    {
                        fto.SetValue(to, tmpValue, null);
                    }
                }
            }
        }
    }
}
