using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MoneyChecker.Commands.CurencyConverter
{
    class CurencyConverter
    {
        /* -------------------------- Настройки -------------------------- */

        private string _uri = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?date=";
        private string _endUri = "&json";

        /* -------------------------- Переменные -------------------------- */
        /// <summary>
        /// Хранит сущности Currency
        /// </summary>
        private List<Currency> _currencies = new List<Currency>();
        /// <summary>
        /// Для хранение даты курса
        /// </summary>
        private DateTime? _date = null;

        /* -------------------------- Свойства -------------------------- */
        /// <summary>
        /// Свойство для изменения адресса данных в завистмости от даты
        /// </summary>
        private string Uri 
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
        /// <summary>
        /// Свойство для возврата списка сущности Currency
        /// </summary>
        public List<Currency> Currencies
        { get 
            {
                return _currencies; 
            } 
        }

        /* -------------------------- Методы -------------------------- */
        /* ---------Обновление данных */
        /// <summary>
        /// Обновить курс валют на текущую дату
        /// </summary>
        public void UpdCurrenciesToCurrentDate()
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = client.GetAsync(Uri).Result;

            var responceCurrencies = response.Content.ReadAsStringAsync().Result;

            _currencies = JsonConvert.DeserializeObject<List<Currency>>(responceCurrencies);
        }
        /// <summary>
        /// Обновить курс валют на указаную дату
        /// </summary>
        /// <param name="date">Дата на какую обновлять курс</param>
        public void UpdCurrenciesByDate(DateTime date)
        {
            _date = date;

            HttpClient client = new HttpClient();

            HttpResponseMessage response = client.GetAsync(Uri).Result;

            var responceCurrencies = response.Content.ReadAsStringAsync().Result;

            _currencies = JsonConvert.DeserializeObject<List<Currency>>(responceCurrencies);
        }

        /* --------- Возврат данных*/
        /// <summary>
        /// Возвращает список валют 
        /// </summary>
        /// <returns>List<string>Currencies.name</returns>
        public List<string> GetCurrenciesName() 
        { 
            List<string> list = new List<string>();
            string name;

            foreach (Currency currency in _currencies) 
            {
                name = $"{currency.Txt} | {currency.Cc}";

                list.Add(name);
            }

            return list;
        }

        /* ---------Расчит стоимости валют */
        /// <summary>
        /// Расчет стоимости валюты без учета даты
        /// </summary>
        /// <param name="count">количество</param>
        /// <param name="nameMyValut"></param>
        /// <param name="nameWantValut"></param>
        /// <returns></returns>
        public double CalculateWithoutDate(double count, string nameMyValut, string nameWantValut)
        {
            double rezult;
            double wantValut;

            if (nameMyValut == "Гривні")
            {
                wantValut = _currencies.FirstOrDefault
                        (v => v.Txt == nameWantValut.Split('|')[0].Trim()).Rate;
                rezult = count / wantValut;

            }
            else
            {
                wantValut = _currencies.FirstOrDefault
                        (v => v.Txt == nameMyValut.Split('|')[0].Trim()).Rate;
                rezult = count * wantValut;
            }
                        
            return Math.Round(rezult, 3); 
        }


    }
}
