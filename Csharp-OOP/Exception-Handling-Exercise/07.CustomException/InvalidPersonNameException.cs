using System;
using System.Collections.Generic;
using System.Text;

namespace _06.ValidPerson
{
    public class InvalidPersonNameException : Exception
    {
        public InvalidPersonNameException(string message) 
            : base(message)
        {
        }
    }
}
