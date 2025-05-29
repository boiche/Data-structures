using DesignPatterns.Creational.Builder;
using DesignPatterns.Creational.Builder.PhoneBuilders.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Tests.Creational
{
    [TestClass]
    public class BuilderPattern
    {
        [TestMethod]
        public void CreatePhone_Successfully()
        {
            //NOTE: Builder pattern is not intented to create immutable objects
            var phone = new SamsungPhoneBuilder(SamsungModels.S9Plus).BuildCamera().BuildOS().BuildProcessor().Build();
            var phoneOld = new SamsungPhoneBuilder(SamsungModels.S9).BuildOS().BuildProcessor().Build();
            Assert.IsNotNull(phone);
            Assert.IsNotNull(phoneOld);
            Assert.AreEqual("S9Plus", phone.Model);
            Assert.AreEqual("Android", phone.OperatingSystem.Name);
            Assert.AreNotEqual(phoneOld.Camera.Model, phone.Camera.Model);
        }
    }
}