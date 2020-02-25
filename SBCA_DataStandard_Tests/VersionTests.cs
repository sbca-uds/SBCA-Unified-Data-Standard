using NUnit.Framework;

namespace SBCA.UnifiedDataStandard.Tests
{
    [TestFixture]
    public class VersionTests
    {
        [Test]
        public void VersionConstructorsTest()
        {
            var version1 = new Version(1, 2, 3);
            var version2 = new Version("1.2.3");
            var versionSpecial = new Version(1, 2, 3, "Special");
            var version2Special = new Version("1.2.3+Special");

            Assert.AreEqual(1, version1.MajorVersion);
            Assert.AreEqual(2, version1.MinorVersion);
            Assert.AreEqual(3, version1.PatchVersion);

            Assert.AreEqual(1, version2.MajorVersion);
            Assert.AreEqual(2, version2.MinorVersion);
            Assert.AreEqual(3, version2.PatchVersion);

            Assert.AreEqual(1, versionSpecial.MajorVersion);
            Assert.AreEqual(2, versionSpecial.MinorVersion);
            Assert.AreEqual(3, versionSpecial.PatchVersion);
            Assert.AreEqual("Special", versionSpecial.Build);

            Assert.AreEqual(1, version2Special.MajorVersion);
            Assert.AreEqual(2, version2Special.MinorVersion);
            Assert.AreEqual(3, version2Special.PatchVersion);
            Assert.AreEqual("Special", version2Special.Build);
        }

        [Test]
        public void VersionToStringTest()
        {
            var version1 = new Version(1, 2, 3);
            var versionSpecial = new Version(1, 2, 3, "Special");

            Assert.AreEqual("1.2.3", version1.ToString());
            Assert.AreEqual("1.2.3+Special", versionSpecial.ToString());
        }
    }
}
