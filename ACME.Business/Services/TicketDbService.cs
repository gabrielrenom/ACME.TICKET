using ACME.Common.Interfaces;
using ACME.Common.Managers;
using ACME.Common.Models;
using ACME.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.Business.Services
{
    public class TicketDbService : ITicketService
    {
        private ITicketManager ticketManager;

        public string Address { get; set; }

        public TicketDbService(ITicketManager ticketmanager)
        {
            ticketManager = ticketmanager;
        }      

        public async Task AddAsync(TicketModel ticket)
        {
            await ticketManager.AddAsync(ticket);
        }

        public  void Add(TicketModel ticket)
        {
            ticketManager.Add(ticket);
        }

        public async Task<IEnumerable<TicketModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<TicketModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TicketModel> Update(TicketModel ticket)
        {
            throw new NotImplementedException();
        }
        
        void ITicketService.Add(TicketModel ticket)
        {
            ticketManager.Add(ticket);
        }
    }
}
