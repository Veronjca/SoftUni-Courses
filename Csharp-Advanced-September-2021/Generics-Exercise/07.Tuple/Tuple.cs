using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Tuple
{
    public class Tuple<T, T1>
    {

        public Tuple(T firstItem, T1 secondItem)
        {
            FirstItem = firstItem;
            SecondItem = secondItem;
        }
        public T FirstItem { get; set; }
        public T1 SecondItem { get; set; }

        public override string ToString()
        {
            return $"{FirstItem} -> {SecondItem}";
        }

    }
}
