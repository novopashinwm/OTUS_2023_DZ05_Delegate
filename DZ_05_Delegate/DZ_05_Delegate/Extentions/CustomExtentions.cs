using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_05_Delegate.Extentions
{
    public static class CustomExtentions
    {
        public static T GetMax<T, TCompare>(this IEnumerable<T> collection, Func<T, TCompare> func) where TCompare : IComparable<TCompare> 
        {
            T? maxItem = default;
            TCompare? maxValue = default;
            collection.ToList().ForEach(item => 
            {
                if (maxItem == null || func(item).CompareTo(maxValue) > 0) 
                {
                    maxValue = func(item);
                    maxItem = item;
                }
            });
            return maxItem;
        }
    }
}
