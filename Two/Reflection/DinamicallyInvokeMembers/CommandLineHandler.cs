using System;
using System.Reflection;
using System.Diagnostics;

namespace Two.Reflection.DinamicallyInvokeMembers
{
    public class CommandLineHandler
    {
        public static void Parse(string[] args, object commandLine)
        {
            string errorMessage;

            if (!TryParse(args, commandLine, out errorMessage))
                throw new ApplicationException(errorMessage);
        }

        public static bool TryParse(string[] args, object commandLine, out string errorMessage)
        {
            bool success = false;
            errorMessage = null;

            foreach (string arg in args)
            {
                string option;

                if (arg[0] == '/' || arg[0] == '-')
                {
                    string[] optionParts = arg.Split(new char[] { ':' }, 2);
                    option = optionParts[0].Remove(0, 1); // Remove the slash|dash

                    // option is the identifier
                    // BindingFlags are the things to look for; basically a filtering
                    PropertyInfo property = commandLine.GetType().GetProperty(option,
                        BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);

                    if (property != null)
                    {
                        if (property.PropertyType == typeof(bool))
                        {
                            // Last parameters (params) for handling indexers
                            // The index parameter is null unless the property is an indexer
                            property.SetValue(commandLine, true, null);
                            success = true;
                        }

                        else if (property.PropertyType == typeof(string))
                        {
                            property.SetValue(commandLine, optionParts[1], null);
                            success = true;
                        }

                        else if (property.PropertyType.IsEnum)
                        {
                            try
                            {
                                property.SetValue(commandLine, 
                                    Enum.Parse(typeof(ProcessPriorityClass), optionParts[1], true), null);
                                success = true;
                            }
                            catch (ArgumentException)
                            {
                                success = false;
                                errorMessage = $@"The option '{ optionParts[1] }' is invalid for '{ option }'";
                            }
                        }
                        else
                        {
                            success = false;
                            errorMessage = $@"Data type '{ 
                                property.PropertyType.ToString() 
                                }' on { 
                                commandLine.GetType().ToString()
                                } is not supported.";
                        }
                    }
                    else
                    {
                        success = false;
                        errorMessage =
                        $"Option '{ option }' is not supported.";
                    }
                }
            }

            return success;
        }
    }
}
