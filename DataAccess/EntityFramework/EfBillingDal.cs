using Core.EfEnityRepository;
using DataAccess.Contexts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfBillingDal : EfEnityRepositoryBase<Billing, KotonContext>, IBillingDal
    {
    }
}
