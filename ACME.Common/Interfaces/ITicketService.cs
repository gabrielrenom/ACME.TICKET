using ACME.Common.Models;
using ACME.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.Common.Interfaces
{
    public interface ITicketService: IMSQAddress
    {
        Task AddAsync(TicketModel ticket);
        void Add(TicketModel ticket);
        Task<bool> Remove(int id);
        Task<TicketModel> Update(TicketModel ticket);
        Task<TicketModel> GetById(int id);
        Task<IEnumerable<TicketModel>> GetAll();
    }
}
