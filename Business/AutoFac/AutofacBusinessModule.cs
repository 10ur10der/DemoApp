using Autofac;
using DataAccess;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoFac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OrderManager>().As<IOrderService>();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>();

            builder.RegisterType<BillingManager>().As<IBillingService>();
            builder.RegisterType<EfBillingDal>().As<IBillingDal>();

            builder.RegisterType<ProductManger>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();
        }
    }
}
