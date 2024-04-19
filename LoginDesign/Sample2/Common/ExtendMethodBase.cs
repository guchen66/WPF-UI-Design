using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample2.Common
{
    /// <summary>
    /// 便于应用的扩展方法
    /// </summary>
    static class ExtendMethodBase
    {
        public static int MyCount<T>(this IEnumerable<T> list)
        {
            int sum = 0;
            var e = list.GetEnumerator();//枚举数
            while (e.MoveNext())
            {
                sum++;
            }
            return sum;
        }
        //string的扩展方法
        public static int ToInt(this String str)
        {
            return int.Parse(str);
        }
        // list的扩展方法
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> func)
        {
            foreach (var item in source)
            {
                func(item);
            }
        }
        //C#本质论抄的
        public static IEnumerable<string> Lines(this StreamReader source)
        {
            if (source == null)
            {
                throw new ArgumentException("source");
            }
            string line;
            while ((line = source.ReadLine()) != null)
            {
                yield return line;
            }
        }
        //字符串扩展方法
        /// <summary>
        /// 如何判断字符串是数字
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsInt(this string s)
        {

            return s.Trim().All(a => Char.IsNumber(a));
        }
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
    }
}
