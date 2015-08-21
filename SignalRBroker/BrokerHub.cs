using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace SignalRBroker
{
    public class BrokerHub : Microsoft.AspNet.SignalR.Hub
    {
        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
            System.Web.HttpContextBase httpContext = Context.Request.GetHttpContext();

        }

        public void SendToGroup(string group, string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.Group(group).broadcastMessage(name, message);
            System.Web.HttpContextBase httpContext = Context.Request.GetHttpContext();

        }

        public override Task OnConnected()
        {
            var sessionId = Context.QueryString["sessionId"];
            if (sessionId != null && sessionId != String.Empty)
            {
                Groups.Add(Context.ConnectionId, sessionId);
            }

            return base.OnConnected();
        }



    }
}