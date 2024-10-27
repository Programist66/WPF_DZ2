using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagrams
{
    class MonthSale
    {
        public MonthSale(DateTime date, double sale)
        {
            Date = date;
            Sale = sale;
        }

        public DateTime Date {  get; set; }
        public double Sale {  get; set; }
    }
}
