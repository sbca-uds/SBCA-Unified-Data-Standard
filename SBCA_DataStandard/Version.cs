using System;

namespace SBCA.UnifiedDataStandard
{
    /// <summary>
    /// Semantic Versioning Modeled after: https://semver.org/
    /// </summary>
    public class Version
    {
        public Version(int majorVersion, int minorVersion, int patchVersion, string build = "")
        {
            MajorVersion = majorVersion;
            MinorVersion = minorVersion;
            PatchVersion = patchVersion;
            Build = build;
        }

        public Version(string version)
        {
            var versionParts = version.Split('.','+');
            MajorVersion = int.Parse(versionParts[0]);
            MinorVersion = int.Parse(versionParts[1]);
            PatchVersion = int.Parse(versionParts[2]);
            if(versionParts.Length > 3)
            {
                if (versionParts.Length > 4) 
                    throw new ArgumentException($"Version parameter {version} has invalid format. Refer to https://semver.org/ for correct format.");
                Build = versionParts[3];
            }

        }


        public int MajorVersion { get; set; }

        public int MinorVersion { get; set; }

        public int PatchVersion { get; set; }

        public string Build { get; set; }

        public override string ToString()
        {
            var versionString = $"{MajorVersion}.{MinorVersion}.{PatchVersion}";
            if (Build != "") versionString += $"+{Build}";
            return versionString;
        }
    }
}
