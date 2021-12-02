using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        public int ID { get; set; }
        public  Product Product { get; set; }
        public int Quantity { get; set; }
        public  Customer Customer { get; set; }
        public string Status { get; set; }
    }
}
