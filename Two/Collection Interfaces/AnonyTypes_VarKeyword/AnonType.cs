using static System.Console;

namespace Two.Collection_Interfaces.AnonyTypes_VarKeyword
{
    /*
        To be of the same data type, the anonymous types have to match
            in PROPERTY NAMES, DATA TYPES, and ORDER of properties

        Anonymous types are immutable
        Anonymous types properties are read-only
    */

    // var => implicitly typed local variable
    class AnonType
    {
        public static void Start ()
        {
            #region Declare

            #region Same Type
            var patent1 = 
                new
                {
                    Title = "Bifocals",
                    YearOfPublication = "1784"
                };
            var patent2 =
                new
                {
                    Title = "Phonograph",
                    YearOfPublication = "1877"
                };
            #endregion
            
            var patent3 =   // type 2
                new
                {
                    patent1.Title,
                    Year = patent1.YearOfPublication
                };

            var patent4 =   // type 3
                new
                {
                    YearOfPublication = "1665",
                    Title = "Something"
                };

            #endregion
            
            WriteLine();
        }
    }
}
