using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T>
    {
        public EqualityScale(T firstElement, T secondElement)
        {
            FirstElement = firstElement;
            SecondElement = secondElement;
        }
        public T FirstElement{ get; set; }
        public T SecondElement { get; set; }

        public bool AreEqual()
        {
            return FirstElement.Equals(SecondElement);
        }

    }
}
