using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTBill.ViewModels
{
    class BaseViewModel : BindableBase
    {
        //public InteractionRequest<INotification> NotificationRequest { get; private set; }

        //public BaseViewModel()
        //{
        //    NotificationRequest = new InteractionRequest<INotification>();
        //}

        //protected void RaiseNotification(string title, string message)
        //{
        //    this.NotificationRequest.Raise(
        //       new Notification { Content = message, Title = title });
        //}
    }
}
