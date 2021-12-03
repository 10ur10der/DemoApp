using Core.EfEnityRepository;
using DataAccess.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
     public class EfProductDal : EfEnityRepositoryBase<Product, KotonContext>, IProductDal
    {

    }
}
