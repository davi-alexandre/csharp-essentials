using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two.Inheritance
{
    internal interface IToString
    {
        string Name { get; }
        string ToString();
    }

    internal sealed class StringClass : object, IToString
    {
        public string Name { get; private set; }

        public StringClass(string name)
        {
            Name = name;
        }

        public override sealed string ToString()
        {
            Console.WriteLine(Name);
            return base.ToString();
        }
    }
}
