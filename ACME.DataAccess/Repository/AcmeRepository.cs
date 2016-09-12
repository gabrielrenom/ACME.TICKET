using ACME.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.DataAccess.Repository
{
    public class AcmeRepository : GenericRepository<ACMEContext>, IACMERepository
    {
    }
}
