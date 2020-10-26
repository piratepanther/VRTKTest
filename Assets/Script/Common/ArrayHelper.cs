using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

namespace Assets.Script.Common
{
    /// <summary>
    /// 7个方法，查找/查找所有满足条件的对象
    /// 升序/降序 最大值  最小值筛选
    /// </summary>
    public static class ArrayHelper
    {
        public static T Find<T>(this T[] array, Func<T,bool> condition)
        {
            for (int i = 0; i < array.Length; i++)
            {
                //满足条件【调用者指定条件】
                if (condition(array[i]))
                {
                    return array[i];
                }
            }
            //泛型的默认值
            return default(T);
        }

        public static T[] FindAll<T>(this T[] array, Func<T, bool> condition)
        {
            //集合存储满足条件的元素
            List<T> list = new List<T>();
            for (int i = 0; i < array.Length; i++)
            {
                if (condition(array[i]))
                {
                    list.Add(array[i]);
                }
            }
            return list.ToArray();
        }

        public static T GetMax<T,Q>(this T[] array, Func<T, Q> condition) where Q:IComparable
        {
            T max = array[0];
            for (int i = 0; i < array.Length; i++) 
            {
                //if (max<array[i])
                if (condition(max).CompareTo(array[i])<0)
                {
                    max = array[i];                    
                }
            }
            return max;
        }

        public static T GetMin<T, Q>(this T[] array, Func<T, Q> condition) where Q : IComparable
        {
            T min = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                //if (max<array[i])
                if (condition(min).CompareTo(array[i]) > 0)
                {
                    min = array[i];
                }
            }
            return min;
        }

        public static T[] OrderBy<T,Q>(this T[] array, Func<T, Q> condition) where Q : IComparable
        {
            for (int i = 0; i < array.Length-1; i++)
            {
                for (int j = 0; j < array.Length-1-i; j++)
                {
                    //if(array[j]> array[j + 1])
                    
                    if (condition(array[j]).CompareTo(array[j+1]) > 0)
                    {
                        T temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            return array;
        }

        public static T[] OrderDescending<T, Q>(this T[] array, Func<T, Q> condition) where Q : IComparable
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    //if(array[j]> array[j + 1])

                    if (condition(array[j]).CompareTo(array[j + 1]) < 0)
                    {
                        T temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            return array;
        }

        public static Q[] Select<T,Q>(this T[] array, Func<T, Q> condition)
        {
            Q[] result = new Q[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                //筛选条件【满足就放入Q[]】
                result[i] = condition(array[i]);                
            }
            return result;
        }

    }
}
