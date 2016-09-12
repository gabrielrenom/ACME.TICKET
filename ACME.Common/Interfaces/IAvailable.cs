using ACME.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.Business.Common
{
    public interface IAvailableService: IMSQAddress
    {
        bool IsDateAvailable(DateTime date);
    }
}
