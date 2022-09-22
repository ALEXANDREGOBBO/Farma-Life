using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cadastro_remedios.Models
{
    public class Sell
    {
        public int sellId { get; set; }
        public string sellDate { get; set; }
        public string sellNetAmount { get; set; }
        public string sellGrossAmount { get; set; }
        public string sellStatus { get; set; }
        public string sellDiscount { get; set; }
        public string sellHour { get; set; }
    }
}
