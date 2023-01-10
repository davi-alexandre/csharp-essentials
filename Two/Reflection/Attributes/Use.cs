using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two.Reflection.Attributes
{
    public class MarkAsRequiredAttribute : Attribute { }

    public class SwitchAliasAttribute : Attribute
    {
        public SwitchAliasAttribute (string alias)
        {
            Alias = alias;
        }
        public string Alias { get; }
    }

    public class DescriptionAttribute : Attribute
    {
        public DescriptionAttribute (string message)
        {
            Message = message;
        }
        public string Message { get; }
    }

    // It is convention to provide an "Attribute" suffix
    // when declaring custom attributes

    // But, when applying an attribute, it is not necessary
    // to provide the "Attribute" suffix

    class Usage
    {
        [MarkAsRequired]
        [SwitchAlias("Persons name")]
        public string Name1 { get; set; }
        //
        //      Is equivalent to...
        //
        [MarkAsRequired, SwitchAlias("Persons name")]
        public string Name2 { get; set; }

        public static void Start()
        {

        }

        [return: Description("Returns true if the object is in a valid state.")]
        public bool IsValid() => true;
    }
}
