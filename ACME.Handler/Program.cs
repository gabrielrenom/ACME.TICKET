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
using System.Configuration;
using Ninject;
using ACME.Handler.Ninject;

namespace ACME.Handler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Adding Dependency injection           
            //KernelBase kernel = new StandardKernel(new NinjectWEBModule());
            //IAvailableService ticketService = kernel.Get<AvailableDbService>();

            Console.WriteLine("+------------------------------------+");
            Console.WriteLine("|--ACME Ticket Availability Handler--|");
            Console.WriteLine("+------------------------------------+");
            
            // Configuration is added
            var messagequeueAddress = ConfigurationManager.AppSettings["ACME:AvailabilityHandler"];

            // If queue doesn't exits it is created
            if (!MessageQueue.Exists(messagequeueAddress)) MessageQueue.Create(messagequeueAddress);

            IAvailableService available = new AvailableDbService();

            // Processing the date
            using (var queue = new MessageQueue(messagequeueAddress))
            {
                Console.WriteLine("Listening... [{0}]", messagequeueAddress);

                while (true)
                {                    
                    var message = queue.Receive();                    
                    var messageBody = JsonConvert.DeserializeObject(new StreamReader(message.BodyStream).ReadToEnd(), Type.GetType(message.Label));                    
                    var messageType = messageBody.GetType();

                    if (messageType == typeof(DateModel))
                    {
                        DateModelAvailable exists = new DateModelAvailable { IsAvailable = available.IsDateAvailable(((DateModel)messageBody).Date) };

                        using (var queueResponse = message.ResponseQueue)
                        {
                            var response = new Message();
                            response.BodyStream = new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(exists)));
                            response.Label = exists.GetType().AssemblyQualifiedName;
                            queueResponse.Send(response);
                            Console.WriteLine("[Message::{0}:: availability: {1}]", message.Id, exists.IsAvailable);
                        }
                    }
                }
            }
        }
    }
}