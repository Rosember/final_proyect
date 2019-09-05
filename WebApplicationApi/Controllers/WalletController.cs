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
        [Route("addMoney/{money}")]
        //[ActionName("addMoney")]
        public IHttpActionResult addMoney(decimal money)
        {
            var wallet = WalletSingleton.Instance;
            var last = wallet.getStatements().Last();

            Communicator communicator = new Communicator();
            if (money <= 0)
            {
                communicator.Message = "Solo valores positivos";
                communicator.Money = last.Money;
                communicator.State = false;
                return Ok(communicator);
            }

            var currentBalance = last.Money + money;

            communicator.Message = "Correcto";
            communicator.Money = currentBalance;
            communicator.State = true;

            wallet.getStatements().Add(communicator);
            return Ok(communicator);

        }

        [HttpGet]
        [Route("subtractMoney/{money}")]
        //[ActionName("addMoney")]
        public IHttpActionResult subtractMoney(decimal money)
        {
            var wallet = WalletSingleton.Instance;
            var last = wallet.getStatements().Last();

            Communicator communicator = new Communicator();
            communicator.Money = wallet.getStatements().Last().Money;
            communicator.State = false;

            if (money <= 0)
            {
                communicator.Message = "Solo valores positivos";
                return Ok(communicator);
            }

            if (money > last.Money)
            {
                communicator.Message = "Saldo insuficiente";
                return Ok(communicator);
            }

            var currentBalance = last.Money - money;
            

            communicator.Message = "Correcto";
            communicator.Money = currentBalance;
            communicator.State = true;

            wallet.getStatements().Add(communicator);
            return Ok(communicator);
        }
    }
}
