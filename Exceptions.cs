using System;
using System.Collections.Generic;
using System.Text;

namespace Race
{
    class BadType : Exception
    {
        public BadType(string message) : base(message)
        {
        }
    }
    class MyException : Exception
    {

        public MyException(string message) : base(message)
        {
        }
    }
}