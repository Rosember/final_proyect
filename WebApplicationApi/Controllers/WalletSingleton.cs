using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationApi.Models;

namespace WebApplicationApi.Controllers
{
    public class WalletSingleton
    {
        private readonly static WalletSingleton _instance = new WalletSingleton();
        private List<Communicator> statements;

        private WalletSingleton()
        {
            statements = new List<Communicator>();
            statements.Add(new Communicator()
            {
                Message = "Correcto",
                Money = 0,
                State = true
            });
        }

        public static WalletSingleton Instance
        {
            get
            {
                return _instance;
            }
        }

        public List<Communicator> getStatements()
        {
            return statements;
        }
    }
}