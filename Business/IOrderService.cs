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
        IResult Add(Order product);
        IResult Update(Order product);
    }
}
