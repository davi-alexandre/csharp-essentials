using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One
{
    internal class Objeto : object
    {
        public int Property { get; set; } = 7;
        public int Constant { get; }

        public Objeto(int property, int constant = 0)
        {
            Property = property;
            Constant = constant;
        }


    }

    internal class ObjectInitializers : object
    {
        private static void Main()
        {

            /*  var obj = new Objeto(10, 1);
                obj.Property = 11;          */
            var obj = new Objeto(property: 10, constant: 1) { Property = 11 };
            // 1- assignment
            // 2- constructor
            // 3- initializer


            Console.WriteLine(obj.Property);
            Console.Read();
        }
    }
}
