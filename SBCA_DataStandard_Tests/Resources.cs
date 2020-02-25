using System.IO;
using System.Reflection;
using static System.IO.Path;
using static System.Linq.Enumerable;


namespace SBCA.UnifiedDataStandard.Tests
{
    public static class Resources
    {
        public static string GetResourceAsString(string fileName)
        {
            return new StreamReader(GetResourceAsStream(fileName)).ReadToEnd();
        }

        public static Stream GetResourceAsStream(string fileName)
        {
            var resourceNames = typeof(Resources).Assembly.GetManifestResourceNames(); // inspect this variable if you are having trouble loading a particular file.

            return typeof(Resources).Assembly.GetManifestResourceStream($"SBCA.UnifiedDataStandard.Tests.Resources.{fileName}");
        }

        public static string GetParentDirectory(int count)
        {
            return Combine(Repeat($"..{DirectorySeparatorChar}", count).ToArray());
        }

        public static string SchemaDirectory { get; } = $"{Combine(GetDirectoryName(Assembly.GetExecutingAssembly().Location), GetParentDirectory(3))}{DirectorySeparatorChar}Resources";

    }
}
