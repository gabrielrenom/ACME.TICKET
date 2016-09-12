using ACME.Common.Managers;
using ACME.Common.Models;
using ACME.Common.Repository;
using ACME.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.DataAccess.Managers
{
    public class TicketManager : BaseACMEManager<TicketModel, Ticket>, ITicketManager
    {
        public TicketManager(IACMERepository repository)
            : base(repository)
        {
            Repository = repository;
        }

        public override TicketModel ToDomainModel(Ticket dataModel)
        {
            return new TicketModel
            {
                Address = dataModel.Address,
                CCName = dataModel.CCName,
                CCNumber = dataModel.CCNumber,
                Created = dataModel.Created,
                Date = dataModel.Date,
                FirstName = dataModel.FirstName,
                Id = dataModel.Id,
                LastName = dataModel.LastName,
                Modified = dataModel.Modified,
                QueueId = dataModel.QueueId
            };
        }

        public override Ticket ToDataModel(TicketModel domainModel, Ticket dataModel = null)
        {
            if (dataModel == null)
                dataModel = new Ticket();

            dataModel.Address = domainModel.Address;
            dataModel.CCName = domainModel.CCName;
            dataModel.CCNumber = domainModel.CCNumber;
            dataModel.Created = DateTime.Now;
            dataModel.Modified = domainModel.Modified;
            dataModel.Date = domainModel.Date;
            dataModel.FirstName = domainModel.FirstName;
            dataModel.Id = domainModel.Id;
            dataModel.LastName = domainModel.LastName;
            dataModel.QueueId = domainModel.QueueId;            

            return dataModel;
        }

    }
}
