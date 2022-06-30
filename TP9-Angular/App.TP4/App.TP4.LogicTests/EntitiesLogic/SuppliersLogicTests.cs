using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.TP4.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.TP4.Logic.Tests
{
    [TestClass()]
    public class SuppliersLogicTests
    {
        [TestMethod()]
        public void GetLastIDTest()
        {
            SuppliersLogic suppliersLogic = new SuppliersLogic();
            int idEsperado = 22;

            int retorno = suppliersLogic.GetLastID();

            Assert.AreEqual(retorno, idEsperado);
        }

        [TestMethod()]
        public void ValidateIDTest()
        {
            SuppliersLogic suppliersLogic = new SuppliersLogic();
            int id = 2;
            try
            {
                suppliersLogic.ValidateID(id);
                Assert.Fail();
            }
            catch(InvalidOperationException ex)
            {
                
            }
            catch(Exception ex)
            {
                Assert.Fail();
            }
        }
    }
}