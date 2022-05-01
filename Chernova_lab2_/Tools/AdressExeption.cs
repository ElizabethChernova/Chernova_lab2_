using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chernova_lab2_.Tools
{
    class AdressExeption : ArgumentException
    {
       
            public String Value { get; }
            public AdressExeption(string message, String val)
                : base(message)
            {
                Value = val;
            }
        }
    }

