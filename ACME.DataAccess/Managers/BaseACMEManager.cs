using ACME.Common.Managers;
using ACME.Common.Models;
using ACME.Common.Repository;
using ACME.Data;
using ACME.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.DataAccess.Managers
{
    public abstract class BaseACMEManager<TD, TE> : BaseManager<TD, TE>, IBaseACMEManager<TD, TE>
       where TD : BaseModel, new()
       where TE : BaseEntity, new()
    {
        protected BaseACMEManager(IACMERepository repository)
            : base(repository)
        {
        }

        /// <summary>
        /// Exposes the underlying repository and context.
        /// </summary>
        public AcmeRepository ACPRepository { get { return Repository as AcmeRepository; } }


    }
}
