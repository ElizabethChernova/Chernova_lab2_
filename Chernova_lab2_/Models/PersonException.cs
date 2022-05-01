using System;
using System.Runtime.Serialization;

namespace Chernova_lab2_.Models
{
   
     class PersonException : Exception
    {
        public int Value { get; }
        public PersonException(string message, int val)
            : base(message)
        {
            Value = val;
        }
    }
}