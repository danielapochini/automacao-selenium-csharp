using System;
using System.Runtime.Serialization;

namespace AutomacaoSeleniumCSharp.CustomException
{
    public class NoSuitableDriverFound : Exception
    {
        public NoSuitableDriverFound(string msg) : base(msg)
        {

        }
    }
}