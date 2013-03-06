using Google.GData.Analytics;
using Google.GData.Client;
using System;
using System.Collections.Generic;

namespace ASPNETGoogleAnalytics24.Models
{
    public class APIGoogleAnalytics
    {
        private AnalyticsService _service = new AnalyticsService("API Project");
        private readonly string _feedURL = "https://www.googleapis.com/analytics/v2.4/data?key=SUAKEY";
        private readonly string _usuario = "SEUEMAIL";
        private readonly string _senha = "SUASENHA";
        private readonly string _ids = "SEUIDS";

        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }

        public APIGoogleAnalytics()
        {
            _service.setUserCredentials(_usuario, _senha);
        }

        public List<object[]> ObterDados(string dimensao, string metrica, string ordernarPor, int? limiteResultados = null)
        {
            var query = new DataQuery(_feedURL);

            query.Ids = _ids;
            query.GAStartDate = DataInicio.ToString("yyyy-MM-dd");
            query.GAEndDate = DataTermino.ToString("yyyy-MM-dd");

            query.Dimensions = dimensao;
            query.Metrics = metrica;
            query.Sort = ordernarPor;

            if (limiteResultados != null)
                query.ExtraParameters = "max-results=" + limiteResultados;

            var dataFeed = _service.Query(query);
            var resultados = new List<object[]>();

            foreach (DataEntry item in dataFeed.Entries)
            {
                var resultado = new object[2];

                resultado[0] = item.Dimensions[0].Value;
                resultado[1] = item.Metrics[0].Value;

                resultados.Add(resultado);
            }

            return resultados;
        }
    }
}