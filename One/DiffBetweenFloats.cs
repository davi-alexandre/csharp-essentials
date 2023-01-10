using Calculos = System.Math;
using static System.Console;

namespace One
{
    internal class DiffBetweenFloats : object
    {
        private static float _num1 = default(float);
        private static float _num2 = default(float);

        
        private static void ClearAndPresent ()
        {
            Clear();
            WriteLine("\t\tEQUALITY CONDITIONAL");
            Write("\n");
        }

        private static bool TolerableDifference(float num1, float num2)
        {
            if ( (Calculos.Abs(num1 - num2)) / Calculos.Max(num1, num2) * 100 < 1 )
                return true;
            return false;
        }

        private static void AssignNumbers()
        {
            string input;
            do
            {
                ClearAndPresent();

                Write("Enter first operand: ");
                input = ReadLine();

                if (input == null || input.Contains(" "))
                    continue;

            } while (!float.TryParse(input, out _num1));
            do
            {
                ClearAndPresent();

                Write("Enter second operand: ");
                input = ReadLine();

                if (input == null || input.Contains(" "))
                    continue;

            } while (!float.TryParse(input, out _num2));
            ClearAndPresent();
        }
        

        private static void Main ()
        {
        Init:
            AssignNumbers();

            WriteLine(TolerableDifference(_num1, _num2)
                ? $">\t>\t{_num1} EQUALS {_num2}"
                : $">\t>\t{_num1} DIFFERS FROM {_num2}");

            ReadKey();
            Clear();
            goto Init;
        }
    }
}
