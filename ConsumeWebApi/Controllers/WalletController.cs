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
        
        public ActionResult AgregarSaldo()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> RegistrarSaldo(decimal ingreso)
        {
            Wallet wallet = new Wallet();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/wallet/addMoney/"+ ingreso +"/");
                if (res.IsSuccessStatusCode)
                {
                    var empResponse = res.Content.ReadAsStringAsync().Result;

                    wallet = JsonConvert.DeserializeObject<Wallet>(empResponse);
                }
            }

            return RedirectToAction("Index");
        }


        public ActionResult RetirarSaldo()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> RegistrarSalidaDeSaldo(decimal ingreso)
        {
            Wallet wallet = new Wallet();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/wallet/subtractMoney/" + ingreso + "/");
                if (res.IsSuccessStatusCode)
                {
                    var empResponse = res.Content.ReadAsStringAsync().Result;

                    wallet = JsonConvert.DeserializeObject<Wallet>(empResponse);
                }
            }
            return RedirectToAction("Index");
        }

    }
}