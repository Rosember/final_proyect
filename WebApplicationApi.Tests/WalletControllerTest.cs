using System;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplicationApi.Controllers;
using WebApplicationApi.Models;

namespace WebApplicationApi.Tests
{
    [TestClass]
    public class WalletControllerTest
    {

        [TestMethod]
        public void greaterThanZero()
        {
            // Disponer
            WalletController controller = new WalletController();

            // Actuar
            var result = controller.getMoney() as OkNegotiatedContentResult<Communicator>;

            // Declarar
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Content.Money);
            Assert.AreEqual(true, result.Content.State);
        }

        [TestMethod]
        public void Corretamount()
        {
            // Disponer
            WalletController controller = new WalletController();

            // Actuar
            var result = controller.addMoney(500) as OkNegotiatedContentResult<Communicator>;

            // Declarar
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.Content.Money);
            Assert.AreEqual(true, result.Content.State);
        }

        [TestMethod]
        public void CorretSubtraction()
        {
            // Disponer
            WalletController controller = new WalletController();

            // Actuar
            var result = controller.subtractMoney (200) as OkNegotiatedContentResult<Communicator>;

            // Declarar
            Assert.IsNotNull(result);
            Assert.AreEqual(300, result.Content.Money);
            Assert.AreEqual(true, result.Content.State);
            Assert.AreEqual("Correcto", result.Content.Message);

        }

        [TestMethod]
        public void subtractAmountGreaterThanBalance()
        {
            // Disponer
            WalletController controller = new WalletController();

            // Actuar
            var result = controller.subtractMoney(450) as OkNegotiatedContentResult<Communicator>;

            // Declarar
            Assert.IsNotNull(result);
            Assert.AreEqual("Saldo insuficiente", result.Content.Message);
            Assert.AreEqual(false, result.Content.State);

        }

        [TestMethod]
        public void addOnlyPositiveValuesInAddMoney()
        {
            // Disponer
            WalletController controller = new WalletController();

            // Actuar
            var result = controller.addMoney(-500) as OkNegotiatedContentResult<Communicator>;

            // Declarar
            Assert.IsNotNull(result);
            Assert.AreEqual("Solo valores positivos", result.Content.Message);
            Assert.AreEqual(false, result.Content.State);
        }

        [TestMethod]
        public void addOnlyPositiveValuesInSubtractMoney()
        {
            // Disponer
            WalletController controller = new WalletController();

            // Actuar
            var result = controller.addMoney(-300) as OkNegotiatedContentResult<Communicator>;

            // Declarar
            Assert.IsNotNull(result);
            Assert.AreEqual("Solo valores positivos", result.Content.Message);
            Assert.AreEqual(false, result.Content.State);

        }
    }
}
