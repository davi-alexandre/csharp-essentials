using System;
using static System.Environment;

namespace Two.Inheritance
{
    internal abstract class PdaItem
    {
        protected string FirstName { get; set; }
        protected string LastName { get; set; }
        public virtual string Name
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
            set
            {
                string[] names = value.Split(' ');
                FirstName = names[0];
                LastName = names[1];
            }
        }

        public PdaItem (string name)
        {
            Name = name;
        }

        public abstract string GetSummary();
    }

    internal class Contact : PdaItem
    {
        public Contact (string name, string address)
            : base (name)
        {
            Address = address;
        }

        public string Address { get; set; }
        public override string Name
        {
            get
            {
                return base.Name;
            }

            set
            {
                base.Name = value;
            }
        }

        public override string GetSummary()
        {
            return $"FirstName: { FirstName + NewLine }"
                + $"LastName: { LastName + NewLine }"
                + $"Address: { Address + NewLine }";
        }
    }

    internal class Appointment : PdaItem
    {
        public Appointment (string name, string location)
            : base (name)
        {
            Location = location;
        }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }

        public override string GetSummary()
        {
            return $"Subject: { Name + NewLine }"
                + $"Start: { StartTime + NewLine }"
                + $"End: { EndTime + NewLine }"
                + $"Location: { Location + NewLine }";
        }
    }

}