using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationApi.Controllers
{
    public class WalletSingleton
    {
        private readonly static WalletSingleton _instance = new WalletSingleton();
        private List<decimal> statements;

        private WalletSingleton()
        {
            statements = new List<decimal>();
            statements.Add(0);
        }

        public static WalletSingleton Instance
        {
            get
            {
                return _instance;
            }
        }

        public List<decimal> getStatements()
        {
            return statements;
        }
    }
}