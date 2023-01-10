using System;

namespace One
{
    class PropertyStudies : object
    {
        private int _Age; // single backing field
        public int Age
        {
            get
            {
                return _Age;
            }
            set
            {
                _Age = value;
            }
        }

        // This is an automatically implemented property
        public int Idade { get; set; }  // Shorthand version for properties 
                                        // with a single backing field

        public float Price { get; set; } = 12.333F; // Initialization

        public float Height { get; private set; } // setter accessible only inside the class

        // Error: Autoimplemented properties must have a getter
        // public int Money { set; }

        private static string _Name;  // Providing property validation
        public static string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                    // <=> throw new ArgumentNullException("value");
                }
                else
                {
                    value = value.Trim();
                    if (value == "")
                    {
                        throw new ArgumentException(
                            "<Name> cannot be blank.", nameof(value));
                    }
                    else
                        _Name = value;
                }
            }
        }
    }
}