using Core.Utilities.Results;
using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BillingManager : IBillingService
    {


        private IBillingDal _billingDal;

        public BillingManager(IBillingDal billingDal)
        {
            _billingDal = billingDal;
        }
     
        public IResult Create(Billing billing)
        {
            _billingDal.Add(billing);
            return new SuccessResult(Messages.BillingAdded);
        }

        IDataResult<Billing> IBillingService.GetById(int billingId)
        {
            return new SuccessDataResult<Billing>(_billingDal.Get(filter: p => p.ID == billingId));
        }
    }
}
