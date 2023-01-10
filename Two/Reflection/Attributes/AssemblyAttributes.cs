using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

/*
    Assembly attributes are used to add metadata about the assembly. Visual
    Studio’s Project Wizard, for example, generates an AssemblyInfo.cs file
    that includes numerous attributes about the assembly. Listing 17.10 is an
    example of such a file.
*/
class AssemblyInfo
{
    // General information about an assembly is controlled
    // through the following set of attributes. Change these
    // attribute values to modify the information
    // associated with an assembly.
    [assembly: AssemblyTitle("CompressionLibrary")]
    [assembly: AssemblyDescription("")]
    [assembly: AssemblyConfiguration("")]
    [assembly: AssemblyCompany("IntelliTect")]
    [assembly: AssemblyProduct("Compression Library")]
    [assembly: AssemblyCopyright("Copyright© IntelliTect 2006-2015")]
    [assembly: AssemblyTrademark("")]
    [assembly: AssemblyCulture("")]
    // Setting ComVisible to false makes the types in this
    // assembly not visible to COM components. If you need to
    // access a type in this assembly from COM, set the ComVisible
    // attribute to true on that type.
    [assembly: ComVisible(false)]
    // The following GUID is for the ID of the typelib
    // if this project is exposed to COM.
    [assembly: Guid("417a9609-24ae-4323-b1d6-cef0f87a42c3")]
    // Version information for an assembly consists
    // of the following four values:
    //
    // Major Version
    // Minor Version
    // Build Number
    // Revision
    //
    // You can specify all the values or you can
    // default the Revision and Build Numbers
    // by using the '*' as shown below:
    // [assembly: AssemblyVersion("1.0.*")]
    [assembly: AssemblyVersion("1.0.0.0")]
    [assembly: AssemblyFileVersion("1.0.0.0")]
}
