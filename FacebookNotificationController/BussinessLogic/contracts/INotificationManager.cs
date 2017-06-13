using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic
{
    public interface INotificationManager
    {
       
        Task<List<Notification>> GetNotification(string userName);

        Task<bool> InsertNotification(Notification notification);
        Task<int> GetUnreadNotificationCount(string userName);
    }
}
