using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }
        public override bool IsValid(object obj)
        {
            int numberToValidate = 0;
            if (int.TryParse(obj.ToString(), out numberToValidate))
            {
                if (numberToValidate < minValue || numberToValidate > maxValue)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
