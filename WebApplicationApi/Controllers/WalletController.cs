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
        //[ActionName("getMoney")]
        public IHttpActionResult getMoney()
        {
            var wallet = WalletSingleton.Instance;

            Communicator communicator = new Communicator
            {
                Message = "Correcto",
                Money = wallet.getStatements().Last(),
                State = true
            };
            return Ok(communicator);
        }

        [HttpPut]
        [Route("addMoney")]
        //[Route("addMoney/{money}")]
        //[ActionName("addMoney")]
        public IHttpActionResult addMoney([FromBody]decimal money)
        {
            var wallet = WalletSingleton.Instance;
            var last = wallet.getStatements().Last();

            Communicator communicator = new Communicator();
            if (money <= 0)
            {
                communicator.Message = "Solo valores positivos";
                communicator.Money = wallet.getStatements().Last();
                communicator.State = false;
                return Ok(communicator);
            }

            var currentBalance = last + money;
            wallet.getStatements().Add(currentBalance);

            communicator.Message = "Correcto";
            communicator.Money = wallet.getStatements().Last();
            communicator.State = true;
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
            if (money <= 0)
            {
                communicator.Message = "Solo valores positivos";
                communicator.Money = wallet.getStatements().Last();
                communicator.State = false;
                return Ok(communicator);
            }

            if (money > last)
            {
                communicator.Message = "Saldo insuficiente";
                communicator.Money = wallet.getStatements().Last();
                communicator.State = false;
                return Ok(communicator);
            }

            var currentBalance = last - money;
            wallet.getStatements().Add(currentBalance);

            communicator.Message = "Correcto";
            communicator.Money = wallet.getStatements().Last();
            communicator.State = true;
            return Ok(communicator);
        }
    }
}
