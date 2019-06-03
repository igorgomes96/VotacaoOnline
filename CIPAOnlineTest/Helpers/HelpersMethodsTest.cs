using System;
using System.Collections.Generic;
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

        [TestMethod]
        public void GetRange()
        {
            List<string> lista = new List<string>
            {
                "1", "2"
            };

            var retorno = lista.GetRange(0, 10);

            Assert.IsTrue(retorno.Count == 2);
        }
    }
}
