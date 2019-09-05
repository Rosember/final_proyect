using ConsumeWebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ConsumeWebApi.Controllers
{
    public class WalletController : Controller
    {
        string BaseUrl = "http://localhost:8090/";

        // GET: Wallet
        public async Task<ActionResult> Index()
        {
            List<Wallet> wallet = new List<Wallet>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/wallet/getmoney");
                if (res.IsSuccessStatusCode)
                {
                    var empResponse = res.Content.ReadAsStringAsync().Result;

                    wallet = JsonConvert.DeserializeObject<List<Wallet>>(empResponse);
                }
            }

            return View(wallet);
        }

        public async Task<ActionResult> Agregar()
        {
            List<Wallet> wallet = new List<Wallet>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/wallet/getmoney");
                if (res.IsSuccessStatusCode)
                {
                    var empResponse = res.Content.ReadAsStringAsync().Result;

                    wallet = JsonConvert.DeserializeObject<List<Wallet>>(empResponse);
                }
            }

            return View(wallet);
        }
    }
}