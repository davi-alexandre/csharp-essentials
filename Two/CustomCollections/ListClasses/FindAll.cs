using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two.CustomCollections.ListClasses
{
    class FindAll
    {
        public static void Start()
        {
            List<int> list = new List<int>() { 1, 2, 3, 2 };
            List<int> results = list.FindAll(num => num%2 == 0);

            foreach (int number in results)
                Console.WriteLine(number);
        }
    }
}
