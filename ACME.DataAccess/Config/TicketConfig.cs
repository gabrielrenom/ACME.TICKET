using ACME.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.DataAccess.Config
{
    public class TicketConfig : EntityTypeConfiguration<Ticket>
    {
        public TicketConfig()
        {
            HasKey(t => t.Id);
        }
    }
}
