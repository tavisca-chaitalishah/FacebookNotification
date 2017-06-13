using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContract;
using BussinessLogic;

namespace NotificationAdaptor
{
    public class NotificationHandler : INotificationHandler
    {
        private INotificationManager _handler;

        public NotificationHandler(INotificationManager handler)
        {
            _handler = handler;
        }

        public async Task<int> GetCountOfUnreadMessage(string userName)
        {
            return await _handler.GetUnreadNotificationCount(userName);
        }

        public async Task<List<DataContract.Notification>> GetNotification(string userName)
        {
            List<DataContract.Notification> list = new List<DataContract.Notification>();
            var result = await _handler.GetNotification(userName);
            foreach(var notification in result)
            {
                list.Add(ObjectTranslator.ConvertObjectToDataContract.ToModel(notification));
            }
            return list;
        }

        public async Task<bool> SendNotification(DataContract.Notification notification)
        {
            return await  _handler.InsertNotification(ObjectTranslator.ConvertObjectToBussinessModel.ToDomain(notification));
        }
    }
}
