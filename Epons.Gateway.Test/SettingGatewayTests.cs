using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epons.Gateway.Test
{
    [TestClass]
    public class SettingGatewayTests
    {
        [TestMethod]
        public void Find()
        {
            SettingGateway gateway = new SettingGateway();

            gateway.Update("TestSetting", "123456");

            string result = gateway.Find("TestSetting");

            Assert.AreEqual("123456", result);
        }
    }
}
