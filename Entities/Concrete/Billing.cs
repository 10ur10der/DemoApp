using Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Billing : IEntity
    {
        public int ID { get; set; }
        public decimal ItemPrice { get; set; }
        [NotMapped]
        public Dictionary<string, decimal> Discounts { get; set; }

        [NotMapped]
        public Dictionary<string, decimal> Taxes { get; set; }

        public string JsonTaxes
        {
            get
            {
                if (Taxes == null)
                    return null;
                else
                    return JsonConvert.SerializeObject(Taxes);
            }
            set
            {
                if (value == null)
                    Taxes = null;
                else
                    Taxes = JsonConvert.DeserializeObject<Dictionary<string, decimal>>(value);
            }
        }
        public string JsonDiscounts
        {
            get
            {
                if (Discounts == null)
                    return null;
                else
                    return JsonConvert.SerializeObject(Discounts);
            }
            set
            {
                if (value == null)
                    Discounts = null;
                else
                    Discounts = JsonConvert.DeserializeObject<Dictionary<string, decimal>>(value);
            }
        }

        public decimal TotalCost { get; set; }

    }
}
