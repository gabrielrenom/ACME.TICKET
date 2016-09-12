using ACME.Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
using ACME.Common.Models;
using Newtonsoft.Json;
using System.IO;
using ACME.Common.Interfaces;

namespace ACME.Business.Services
{
    public class AvailableInQueueService : IAvailableService, IMSQAddress
    {        
        public string Address { get; set; }     
        public bool IsDateAvailable(DateTime date)
        {
            // Adding a temp queue per message...
            // It needs to be refactored to use correlation
            var temporalMessageQueue = Guid.NewGuid().ToString().Substring(0, 6);
            temporalMessageQueue = ".\\private$\\" + temporalMessageQueue;
            try
            {
                using (var responseQueue = MessageQueue.Create(temporalMessageQueue))
                {
                    var dateAvailable = new DateModel
                    {
                        Date = date
                    };                    
                    using (var requestQueue = new MessageQueue(Address))
                    {
                        var message = new Message();
                        message.BodyStream = new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(dateAvailable)));
                        message.Label = dateAvailable.GetType().AssemblyQualifiedName;
                        message.ResponseQueue = responseQueue;
                        requestQueue.Send(message);
                    }
                    var response = responseQueue.Receive();
                    var responseBody = JsonConvert.DeserializeObject<DateModelAvailable>(new StreamReader(response.BodyStream).ReadToEnd());
                    return responseBody.IsAvailable;
                }
            }
            finally
            {
                if (MessageQueue.Exists(temporalMessageQueue))
                {
                    MessageQueue.Delete(temporalMessageQueue);
                }
            }
        }
    }
}
