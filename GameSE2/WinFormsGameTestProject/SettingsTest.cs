using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WinFormsGameTestProject
{
    [TestClass]
    public class SettingsTest
    {
        [TestMethod]
        public void SettingsCreationTest()
        {
            Settings settings = new Settings(200,200,720,1080,30);

            Assert.AreEqual(36, settings.ViewWidth, "ViewWidth test 1 incorrect");
            Assert.AreEqual(24, settings.ViewHeight, "ViewHeight test 1 incorrect");

            settings = new Settings(200,200,653,1141,30);

            Assert.AreEqual(38, settings.ViewWidth, "ViewWidth test 2 incorrect");
            Assert.AreEqual(21, settings.ViewHeight, "ViewHeight test 2 incorrect");
        }
    }
}
