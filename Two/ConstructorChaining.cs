using System;

namespace Two
{
    internal class Employee : object
    {
    #region FIELD DECLARATIONS
        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (ValidTextInput(value))
                    _FirstName = value;
            }
        }

        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (ValidTextInput(value))
                    _LastName = value;
            }
        }

        public int ID { get; set; }
    #endregion

    #region CONSTRUCTION
        // base constructor
        public Employee(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        // chained constructor
        public Employee(string firstName, string lastName, int id)
            : this(firstName, lastName)
        {
            ID = id;
        }
    #endregion

        private bool ValidTextInput(string value)
        {
            bool result = false;

            if (value == null)
                throw new ArgumentNullException(
                    nameof(value), "null assignment error");
            else
            {
                value = value.Trim();
                if (value == "")
                    throw new ArgumentException(
                        nameof(value), "Invalid empty assignment");
                else
                    result = true;
            }
            return result;
        }
    }

    internal class ConstructorChaining : object
    {

    }
}
