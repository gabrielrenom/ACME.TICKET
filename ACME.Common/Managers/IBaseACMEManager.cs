using ACME.Common.Models;
using ACME.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.Common.Managers
{  
    public interface IBaseACMEManager<TD, TE> : IBaseManager<TD, TE>
        where TD : BaseModel
        where TE : BaseEntity
    {

    }
}
