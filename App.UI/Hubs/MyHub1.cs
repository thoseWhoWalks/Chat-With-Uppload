using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using App.Model.Api;
using Microsoft.AspNet.SignalR.Hubs;
using App.Model.Services;

namespace App.UI
{
    [HubName("chat")]
    public class MyHub1 : Hub
    {
        static List<AccountModelApi> Users = new List<AccountModelApi>();
        
        public void Send(string message)
        {
            UnitOfWork.Instance.MessageService.Create(new Model.MessageModelApi { Body = message, FromId = UnitOfWork.Instance.AccountService.CurrentUser });

            Clients.All.addMessage(UnitOfWork.Instance.AccountService.CurrentUser.Login, message);
        }
        
        public void Connect()
        {
            if (UnitOfWork.Instance.AccountService.CurrentUser==null)
            {

                return;
            }

            var id = Context.ConnectionId;


            if (!Users.Any(x => x.ConnectionId == id))
            {
                Users.Add(new AccountModelApi { ConnectionId = id,  Login = UnitOfWork.Instance.AccountService.CurrentUser.Login});
                
            }
        }
         
    }
}