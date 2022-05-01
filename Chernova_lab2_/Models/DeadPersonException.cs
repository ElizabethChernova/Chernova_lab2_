using System;
using System.Runtime.Serialization;

namespace Chernova_lab2_.Models
{
 
     class DeadPersonException : Exception
    {
        public int Value { get; }
        public DeadPersonException(string message, int val)
            : base(message)
        {
            Value = val;
        }
    }
}