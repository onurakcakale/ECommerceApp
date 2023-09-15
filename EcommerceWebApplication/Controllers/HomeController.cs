using EcommerceWebApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace EcommerceWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // Request is made to the Web API with HTTPClient. The data in Json format returned from the API is written into the list.
        [HttpPost]
        public JsonResult IndexMethod(int id)
        {
            Uri baseAddress;

            if (id == 0)
                baseAddress = new Uri("https://localhost:44329/api/product");

            else
                baseAddress = new Uri("https://localhost:44329/api/product/" + id);

            HttpClient client = new HttpClient();
            List<ProductViewModel> productList = new List<ProductViewModel>();

            client.BaseAddress = baseAddress;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                productList = JsonConvert.DeserializeObject<List<ProductViewModel>>(data);

            }

            return Json(productList);

        }
    }
}