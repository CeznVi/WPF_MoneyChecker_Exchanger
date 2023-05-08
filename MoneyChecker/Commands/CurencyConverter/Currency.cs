using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyChecker.Commands.CurencyConverter
{
    class Currency
    {
        ///https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?date=20200302&json
        public string R030 { get; set; }
        public string Txt { get; set;}
        public double Rate { get; set;}
        public string Cc { get; set;}
        public string Exchangedate { get; set;}

    }
}
