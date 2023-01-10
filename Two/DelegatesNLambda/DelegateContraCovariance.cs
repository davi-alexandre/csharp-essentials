using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Console;

namespace Two.DelegatesNLambda
{

    class DelegateContraCovariance
    {
        // [in] CONTRAVARIANCE - any action on a broad object can be performed on a narrow one
        static Action<object> broadAction = (object data) => WriteLine(data);
        static Action<string> narrowAction = broadAction;

        // [out] COVARIANCE - Func is covariant in it's return type
        static Func<string> narrowFunc = () => ReadLine();
        static Func<object> broadFunc = narrowFunc;


        // COVARIANCE AND CONTRAVARIANCE COMBINED
        static Func<object, string> func1 = 
            (object data) => data.ToString();
        static Func<string, object> func2 = func1;
    }
}
