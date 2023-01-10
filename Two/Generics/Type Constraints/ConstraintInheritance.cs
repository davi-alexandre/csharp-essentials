using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Two.Generics.Type_Constraints
{

    class Base<B> where B : IComparable<B>
    {
        public B Item { get; set; }
    }


    /*  [D] must have equal or stronger constraints than the base's if 
            the type paramenter of Derived is to be used to set up the Base 
        Otherwise, the base would not accept the type parameter, for it
            wouldn't match up to the constraints                        */

    class Derived<D> : Base<D>
        where D : IComparable<D>    // Produces error without this constraint
    {

    }
}
