using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MoneyChecker.Commands.CurencyConverter
{
    class CurencyConverter
    {
        private List<Currency> _currencies = new List<Currency>();

        private DateTime? _date = null;


        private string _uri = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?date=";
        private string _endUri = "&json";
      
        public string Uri 
        { 
            get 
            { 
                if(_date == null)
                    return _uri + _endUri; 
                else
                    return _uri +
                        (_date.Value.Day.ToString().Length == 1 ? "0" + _date.Value.Day.ToString() : _date.Value.Day.ToString()) + 
                        (_date.Value.Month.ToString().Length == 1 ? "0" + _date.Value.Month.ToString() : _date.Value.Month.ToString()) + 
                        _date.Value.Year+
                        _endUri;
            } 
        }

        public List<Currency> Currencies
        { get 
            {
                return _currencies; 
            } 
        }


        public void UpdCurrenciesToCurrentDate()
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = client.GetAsync(Uri).Result;

            var responceCurrencies = response.Content.ReadAsStringAsync().Result;

            _currencies = JsonConvert.DeserializeObject<List<Currency>>(responceCurrencies);
        }

        public void UpdCurrenciesByDate(DateTime date)
        {
            _date = date;

            HttpClient client = new HttpClient();

            HttpResponseMessage response = client.GetAsync(Uri).Result;

            var responceCurrencies = response.Content.ReadAsStringAsync().Result;

            _currencies = JsonConvert.DeserializeObject<List<Currency>>(responceCurrencies);
        }

    }
}
