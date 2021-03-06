﻿using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BussinessLogic
{
    public class NotificationManager : INotificationManager
    {
        private INotificationStore _store;

        public NotificationManager(INotificationStore store)
        {
            _store = new RedisStorage(store);
        }

        public async Task<List<Notification>> GetNotification(string userName)
        {
            return  await _store.GetAllNotificationAsync(userName);
        }

        public async Task<int> GetUnreadNotificationCount(string userName)
        {
            return await _store.GetUnreadMessageCountAsync(userName);
        }

        public async Task<bool> InsertNotification(Notification notification)
        {
            return await _store.InsertNotificationAsync(notification);
        }
    }
}
