using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ShopTZ.Utils
{
    public static class Observable
    {
        public static ObservableCollection<T> ToObservable<T>(this IEnumerable<T> source)
        {
            return new ObservableCollection<T>(source);
        }
    }
}
