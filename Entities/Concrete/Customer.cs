using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Customer : IEntity
    {
        public int ID { get; set; }
        public int AddressID { get; set; }

        public List<Order> Orders { get; set; }
    }
}
