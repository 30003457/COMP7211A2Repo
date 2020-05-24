using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using COMP7211Assignment2.iOS;
using Foundation;
using UIKit;
[assembly: Xamarin.Forms.Dependency(typeof(Message_ios))]
namespace COMP7211Assignment2.iOS
{
  public class Message_ios : IMessage
        {
            const double LONG_DELAY = 3.5;
            const double SHORT_DELAY = 2.0;

            NSTimer alertDelay;
            UIAlertController alert;

            public void Longtime(string message)
            {
                ShowAlert(message, LONG_DELAY);
            }
            public void shorttime(string message)
            {
                ShowAlert(message, SHORT_DELAY);
            }

            void ShowAlert(string message, double seconds)
            {
                alertDelay = NSTimer.CreateScheduledTimer(seconds, (obj) =>
                {
                    dismissMessage();
                });
                alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);
                UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
            }

            void dismissMessage()
            {
                if (alert != null)
                {
                    alert.DismissViewController(true, null);
                }
                if (alertDelay != null)
                {
                    alertDelay.Dispose();
                }
            }
        }
}
