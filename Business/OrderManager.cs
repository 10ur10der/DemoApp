using Core.Utilities.Results;
using DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public IResult Add(Order product)
        {
            _orderDal.Add(product);
            return new SuccessResult(Messages.OrderAdded);
        }


        public IResult Update(Order product)
        {
            _orderDal.Update(product);
            return new SuccessResult(Messages.OrderUpdated);
        }
    }
}
