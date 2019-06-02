using System;
using CIPAOnLine.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CIPAOnlineTest.Helpers
{
    [TestClass]
    public class HelpersMethodsTest
    {
        [TestMethod]
        public void HorarioBrasilia_RetornaHorarioCorreto()
        {
            // Arrange // Act
            var data = HelpersMethods.HorarioBrasilia();

            // Assert
            Assert.IsTrue(DateTime.Now.Subtract(data) < TimeSpan.FromSeconds(1));
        }
    }
}
