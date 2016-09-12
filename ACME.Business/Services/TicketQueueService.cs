using ACME.Common.Interfaces;
using ACME.Common.Models;
using ACME.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ACME.Business.Services
{
    public class TicketQueueService : ITicketService
    {
        public string Address { get; set; }            

        public async Task AddAsync(TicketModel ticket)
        {
            using (var queue = new MessageQueue(Address))
            {
                var message = new Message();
                message.BodyStream = new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(ticket)));
                message.Label = ticket.GetType().AssemblyQualifiedName;
                queue.Send(message);
            }
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
            throw new NotImplementedException();
        }

        void Add(TicketModel ticket)
        {
            throw new NotImplementedException();
        }
    }
}
