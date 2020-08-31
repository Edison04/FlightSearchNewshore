using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace FlightSearhcNewshore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost, ActionName("BuscarVuelos")]

        public string BuscarVuelos(string Origin, string Destination, DateTime From)
        {
            string date = From.ToString("yyyy-MM-dd");

            string body = "{\"Origin\":\"" + Origin + "\", \"Destination\":\"" + Destination + "\", \"From\":\"" + date + "\"}";

            var restClient = new RestClient("http://testapi.vivaair.com/otatest/");
            var restRequest = new RestRequest(Method.POST);
            restRequest.Resource = "api/values";
            restRequest.AddParameter("application/json", body, ParameterType.RequestBody);

            var response = restClient.Execute(restRequest).Content;

            return response;

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}