using System.Diagnostics;

namespace Two.Reflection.DinamicallyInvokeMembers
{
    public partial class Program
    {
        private class CommandLineInfo
        {
            public bool Help { get; set; }
            public string Out { get; set; }
            public ProcessPriorityClass Priority { get; set; }
                = ProcessPriorityClass.Normal;
        }
    }
}
