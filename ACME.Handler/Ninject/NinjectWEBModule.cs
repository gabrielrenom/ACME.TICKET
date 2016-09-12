using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACME.Common.Interfaces;
using ACME.Business.Common;
using ACME.Business.Services;
using ACME.Common.Repository;
using ACME.DataAccess.Repository;
using ACME.Common.Managers;
using ACME.DataAccess.Managers;

namespace ACME.Handler.Ninject
{
    public class NinjectWEBModule : NinjectModule
    {
        public override void Load()
        {            
            Bind<IACMERepository>().To<AcmeRepository>();            
            Bind<ITicketManager>().To<TicketManager>();            
            Bind<ITicketService>().To<TicketDbService>();
            Bind<IAvailableService>().To<AvailableDbService>();
        }
    }
}
