using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationApi.Models;

namespace WebApplicationApi.Controllers
{
    [RoutePrefix("api/wallet")]
    public class WalletController : ApiController
    {


        [HttpGet]
        [Route("getMoney")]
        public IHttpActionResult getMoney()
        {
            var wallet = WalletSingleton.Instance;
            return Ok(wallet.getStatements());
        }

        [HttpGet]
        [Route("addMoney/{money:decimal}/")]
        //[ActionName("addMoney")]
        public IHttpActionResult addMoney(decimal money)
        {
            var wallet = WalletSingleton.Instance;
            var last = wallet.getStatements().Last();

            Communicator communicator = new Communicator();
            if (EsNumeroPositivo(money))
            {
                var currentBalance = last.Money + money;

                communicator.Message = "Correcto, agregado: " + money;
                communicator.Money = currentBalance;
                communicator.State = true;
            }
            else
            {
                communicator.Message = "Solo valores positivos";
                communicator.Money = last.Money;
                communicator.State = false;
            }
            wallet.getStatements().Add(communicator);
            return Ok(communicator);

        }

        [HttpGet]
        [Route("subtractMoney/{money:decimal}/")]
        //[ActionName("addMoney")]
        public IHttpActionResult subtractMoney(decimal money)
        {
            var wallet = WalletSingleton.Instance;
            var last = wallet.getStatements().Last();

            Communicator communicator = new Communicator();
            communicator.Money = wallet.getStatements().Last().Money;
            communicator.State = false;
            if (EsNumeroPositivo(money))
            {
                if (TieneSaldoSuficiente(money, last.Money))
                {
                    var currentBalance = last.Money - money;
                    communicator.Message = "Correcto, retiro de: " + money;
                    communicator.Money = currentBalance;
                    communicator.State = true;
                }
                else
                {
                    communicator.Message = "Saldo insuficiente";
                }
            }
            else
            {
                communicator.Message = "Solo valores positivos";
            }
            

            wallet.getStatements().Add(communicator);
            return Ok(communicator);
        }

        private static bool EsNumeroPositivo(decimal money)
        {
            return money > 0;
        }

        private static bool TieneSaldoSuficiente(decimal retiro, decimal saldo)
        {
            return saldo >= retiro;
        }
    }
}
