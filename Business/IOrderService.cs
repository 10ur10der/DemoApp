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
        IDataResult<Order> GetById(int productId);
        IDataResult<List<Order>> GetList();
        IDataResult<List<Order>> GetPageToList(int itemsPerPage, int page);
        IResult Add(Order order);
        IResult Delete(Order order);
        IResult Update(Order order);

    }
}
