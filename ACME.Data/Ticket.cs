using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.Data
{
    public class Ticket: BaseEntity
    {       
       public Guid QueueId { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public string Address { get; set;}
       public string CCName { get; set; }
       public string CCNumber { get; set; }
       public DateTime Date { get; set; }
    }
}
