using System.Collections.Generic;

namespace NugetUtility
{
    public class LibraryInfo 
    {
        public string PackageName { get; set; }
        public string PackageVersion { get; set; }
        public string PackageUrl { get; set; }
        public string Copyright { get; set; }
        public string [] Authors { get; set; }
        public string Description { get; set; }
        public string LicenseUrl { get; set; }
        public string LicenseType { get; set; }
        public string Projects { get; set; }
        public LibraryRepositoryInfo Repository { get; set; }

    }

    public class LibraryInfoEqualityComparer: IEqualityComparer<LibraryInfo>
    {
        public bool Equals(LibraryInfo x, LibraryInfo y)
        {
            return x.PackageName == y.PackageName && x.PackageVersion == y.PackageVersion && x.LicenseType == y.LicenseType;
        }

        public int GetHashCode(LibraryInfo obj)
        {
            int hash = 17;
            hash = hash * 23 + obj.PackageName.GetHashCode();
            hash = hash * 23 + obj.PackageVersion.GetHashCode();
            hash = hash * 23 + obj.LicenseType.GetHashCode();
            return hash;
        }
    }

    public class LibraryRepositoryInfo
    {
        public string Type { get; set; }
        public string Url { get; set; }
        public string Commit { get; set; }
    }
}