using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using ProdTracking.Website.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Web;

namespace ProdTracking.Website.Hubs
{
    [HubName("NotificationHub")]
    public class NotificationHub : Hub
    {
        private static readonly ConcurrentDictionary<string, UserHubModels> Users =
       new ConcurrentDictionary<string, UserHubModels>(StringComparer.InvariantCultureIgnoreCase);
      
        public override Task OnConnected()
        {
            string userName =  Context.User.Identity.Name;
            string connectionId = Context.ConnectionId;

            var user = Users.GetOrAdd(userName, _ => new UserHubModels
            {
                UserName = userName,
                ConnectionIds = new HashSet<string>()

            });

            lock (user.ConnectionIds)
            {
                user.ConnectionIds.Add(connectionId);
                
                if (user.ConnectionIds.Count == 1)
                {
                    Clients.Others.userConnected();
                }
                Clients.All.UpdateCount(user.ConnectionIds.Count);
            }
            
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            string userName = Context.User.Identity.Name;
            string connectionId = Context.ConnectionId;

            UserHubModels user;
            Users.TryGetValue(userName, out user);

            if (user != null)
            {
                lock (user.ConnectionIds)
                {
                    user.ConnectionIds.RemoveWhere(cid => cid.Equals(connectionId));
                    if (!user.ConnectionIds.Any())
                    {
                        UserHubModels removedUser;
                        Users.TryRemove(userName, out removedUser);
                        Clients.Others.userDisconnected(userName);
                    }
                    Clients.All.UpdateCount(user.ConnectionIds.Count);
                }
            }
           
            return base.OnDisconnected(stopCalled);
        }

    }
}