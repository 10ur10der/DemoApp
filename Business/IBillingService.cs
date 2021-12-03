using Core.Utilities.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IBillingService
    {
        IResult Create(Billing billing);
        IDataResult<Billing> GetById(int billingId);
    }
}
