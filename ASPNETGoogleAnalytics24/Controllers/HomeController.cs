using ASPNETGoogleAnalytics24.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ASPNETGoogleAnalytics24.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /

        public ActionResult Index()
        {
            var googleAnalitics = new APIGoogleAnalytics();
            var dadosAnalytics = new List<List<object[]>>();

            googleAnalitics.DataInicio = DateTime.Now.AddDays(-30);
            googleAnalitics.DataTermino = DateTime.Now.AddDays(-1);

            dadosAnalytics.Add(googleAnalitics.ObterDados("ga:date", "ga:visits", "ga:date"));

            dadosAnalytics.Add(googleAnalitics.ObterDados("ga:date", "ga:transactionRevenue", "ga:date"));

            dadosAnalytics.Add(googleAnalitics.ObterDados("ga:productName", "ga:itemQuantity", "-ga:itemQuantity", 10));

            dadosAnalytics.Add(googleAnalitics.ObterDados("ga:source", "ga:organicSearches", "-ga:organicSearches", 10));

            dadosAnalytics.Add(googleAnalitics.ObterDados("ga:keyword", "ga:organicSearches", "-ga:organicSearches", 10));

            dadosAnalytics.Add(googleAnalitics.ObterDados("ga:city", "ga:visits", "-ga:visits", 10));

            return View(dadosAnalytics);
        }

    }
}
