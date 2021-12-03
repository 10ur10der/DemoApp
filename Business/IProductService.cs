using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IProductService
    {
        //IDataResult GetStock(int productID);

        IDataResult<Product> GetById(int productId);
        IDataResult<List<Product>> GetList();
        IDataResult<List<Product>> GetPageToList(int itemsPerPage, int page);
        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);
    }
}
