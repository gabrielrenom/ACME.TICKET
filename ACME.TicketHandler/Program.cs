using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
using ACME.Data;
using ACME.Common.Models;
using Newtonsoft.Json;
using System.IO;
using ACME.Business.Common;
using ACME.Business.Services;
using ACME.Common.Interfaces;
using System.Configuration;
using Ninject;
using ACME.TicketHandler.Ninject;
using ACME.Common.Repository;
using ACME.DataAccess.Repository;
using ACME.Common.Managers;
using ACME.DataAccess.Managers;

namespace ACME.TicketHandler
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Adding Dependency injection           
            KernelBase kernel = new StandardKernel(new NinjectWEBModule());
            ITicketService ticketService = kernel.Get<TicketDbService>();

            // Console info...
            Console.WriteLine("+--------------------------------+");
            Console.WriteLine("|--------ACME Ticket Handler-----|");
            Console.WriteLine("+--------------------------------+");

            // Get the address from the config
            var messagequeueAddress = ConfigurationManager.AppSettings["ACME:TicketHandler"];

            // Check if queue exists, if not we create it....
            if (!MessageQueue.Exists(messagequeueAddress)) MessageQueue.Create(messagequeueAddress);

            //ITicketService ticketService = new TicketDbService( );
            ticketService.Address = messagequeueAddress;

            // Start listening to possible tickets to add
            using (var queue = new MessageQueue(messagequeueAddress))
            {
                Console.WriteLine("Listening... [{0}]", messagequeueAddress);

                while (true)
                {                                        
                    var message = queue.Receive();
                    var messageBody = JsonConvert.DeserializeObject(new StreamReader(message.BodyStream).ReadToEnd(), Type.GetType(message.Label));                    
                    var messageType = messageBody.GetType();
                    if (messageType == typeof(TicketModel))
                    {
                        // Adding the ticket...
                        ((TicketModel)messageBody).QueueId = new Guid(message.Id.Split('\\')[0]);
                        ticketService.Add((TicketModel)messageBody);
                    }
                    Console.WriteLine("[Ticket Added:: MessageId:{0}, Last Name:{1}, Date:{2}]", ((TicketModel)messageBody).QueueId, ((TicketModel)messageBody).LastName, ((TicketModel)messageBody).Date);
                }
            }
        }
    }
}
