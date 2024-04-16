using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalaizerClass
{
    public class CalcObjects
    {
        public CalcObjects(string token, int priority)
        {
            Token = token;
            Priority = priority;
        }

        public string Token { get; set; }
        public int Priority { get; set; }

        public bool Equals(CalcObjects other)
        {
            return Priority == other.Priority;
        }


        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

    }
}
