using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public interface IBuyer
    {
        public int Food { get; set; }
        void BuyFood();
    }
}
