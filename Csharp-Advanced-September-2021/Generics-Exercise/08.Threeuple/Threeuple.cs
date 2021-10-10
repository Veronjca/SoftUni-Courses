using System;
using System.Collections.Generic;
using System.Text;

namespace _08.ThreeUple
{
    public class Threeuple<T, T1, T2>
    {
        public Threeuple(T firstItem, T1 secondItem, T2 thirdItem)
        {
            FirstItem = firstItem;
            SecondItem = secondItem;
            ThirdItem = thirdItem;
        }
     
        public T FirstItem { get; set; }
        public T1 SecondItem { get; set; }
        public T2 ThirdItem { get; set; }

        public override string ToString()
        {
            return $"{FirstItem} -> {SecondItem} -> {ThirdItem}";
        }
    }
}
