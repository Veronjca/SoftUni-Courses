using System;
using System.Collections.Generic;
using System.Text;

namespace _05.GenericCountMethodStrings
{
    public class Box<T>
    {
        public Box(T value)
        {
            Value = value;
        }
        public T Value { get; set; }

        public override string ToString()
        {
            return $"{Value.GetType()}: {Value}";
        }
    }
}
