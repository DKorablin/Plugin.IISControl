using System.Reflection;
using System.Runtime.InteropServices;

[assembly: ComVisible(false)]
[assembly: Guid("d8158539-81de-4d83-9087-ece37ea20de3")]
[assembly: System.CLSCompliant(true)]

#if NETCOREAPP
[assembly: AssemblyMetadata("ProjectUrl", "https://github.com/DKorablin/Plugin.IISControl")]
#else

[assembly: AssemblyTitle("Plugin.IISControl")]
[assembly: AssemblyDescription("Internet Information Service client application")]
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif
[assembly: AssemblyCompany("Danila Korablin")]
[assembly: AssemblyProduct("Plugin.IISControl")]
[assembly: AssemblyCopyright("Copyright © Danila Korablin 2011-2024")]
#endif