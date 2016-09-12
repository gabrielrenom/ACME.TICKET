using ACME.Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.Business.Services
{
    public class AvailableDbService : IAvailableService
    {
        public string Address { get; set; }

        public bool IsDateAvailable(DateTime date)
        {
            // EF to be implemented here with the DATAACCESS layer...
            return true;
        }
    }
}
