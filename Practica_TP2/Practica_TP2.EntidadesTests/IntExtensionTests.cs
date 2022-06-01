using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica_TP2.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_TP2.Entidades.Tests
{
    [TestClass()]
    public class IntExtensionTests
    {
        [TestMethod()]
        public void TestIntentarDividirCero()
        {
            int dividendo = 1;
            int divisor = 0;

            int retorno = dividendo.IntentarDividirCero();

            Assert.AreEqual(retorno, divisor);
        }

        [TestMethod()]
        public void TestDividirPor()
        {
            int dividendo = 1;
            int divisor = 1;
            int valorEsperado = 1;

            int retorno = dividendo.DividirPor(divisor);
        
            Assert.AreEqual(retorno, valorEsperado);

        }

        [TestMethod()]
        public void Test_DividirPor()
        {
            int dividendo = 1;
            int divisor = 0;
            int valorEsperado = 0;
 
            int retorno = dividendo.DividirPor(divisor);

            Assert.AreEqual(retorno, valorEsperado);
        }
    }
}