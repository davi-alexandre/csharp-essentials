using System;

namespace Two.Extension_Methods
{
    internal class Instance : object
    {
        private string _Name = null;
        public string Name 
        {
            get { return _Name; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), 
                        "Name cannot be null!");
                }
                else
                {
                    value = value.Trim();
                    if (value == "")
                    {
                        throw new ArgumentException(nameof(value),
                            "Name cannot be blank");
                    }
                    else
                    {
                        _Name = value;
                    }
                }
            }
        }
        
        public Instance (string name) 
        {
            Name = name;
        }
    }
}
