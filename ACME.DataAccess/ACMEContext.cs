using ACME.Data;
using ACME.DataAccess.Config;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.DataAccess
{
    public class ACMEContext : DbContext
    {
        public ACMEContext() : base("ACMEDb")
        {

        }

        static ACMEContext()
        {
            Database.SetInitializer<ACMEContext>(new ACMEInitialiser());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new TicketConfig());            

        }

        public DbSet<Ticket> Tickets { get; set; }      
    }
}
