﻿using Core.EfEnityRepository;
using DataAccess.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccess
{
    public class EfOrderDal : EfEnityRepositoryBase<Order, KotonContext>, IOrderDal
    {
    }
}
