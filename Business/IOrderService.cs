using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IOrderService
    {
        IResult Add(Order order);
        IResult Update(Order order);
    }
}
