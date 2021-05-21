
using UnityEngine;
//using Unity.Notifications.Android;

public class pushnotification : MonoBehaviour
{
    //[SerializeField]
    //private AndroidNotificationChannel defaultNotificationChannel;

    //private int identifier;

    //private void Start()
    //{

    //    defaultNotificationChannel = new AndroidNotificationChannel()
    //    {
    //        Id = "default_channel",
    //        Name = "Default Channel",
    //        Description = "For Generic notifications",
    //        Importance = Importance.Default,
    //    };

    //    AndroidNotificationCenter.RegisterNotificationChannel(defaultNotificationChannel);


    //    AndroidNotification notification = new AndroidNotification()
    //    {
    //        Title = "FourtyFourty",
    //        Text = "Welcomes you to the covid 20 game",
    //        //SmallIcon = "app_icon_entrance",
    //        LargeIcon = "app_icon_entrance",
    //        FireTime = System.DateTime.Now.AddSeconds(5),
    //    };

    //    AndroidNotification notification2 = new AndroidNotification()
    //    {
    //        Title = "Prize Reward",
    //        Text = "Complete all the level and win amazon gift voucher",
    //        //SmallIcon = "app_icon_small",
    //        LargeIcon = "app_icon_gift",
    //        FireTime = System.DateTime.Now.AddSeconds(5),
    //    };

    //    identifier = AndroidNotificationCenter.SendNotification(notification, "default_channel");


    //    AndroidNotificationCenter.NotificationReceivedCallback receivedNotificationHandler = delegate (AndroidNotificationIntentData data)
    //    {
    //        var msg = "Notification received : " + data.Id + "\n";
    //        msg += "\n Notification received: ";
    //        msg += "\n .Title: " + data.Notification.Title;
    //        msg += "\n .Body: " + data.Notification.Text;
    //        msg += "\n .Channel: " + data.Channel;
    //        Debug.Log(msg);
    //    };

    //    AndroidNotificationCenter.OnNotificationReceived += receivedNotificationHandler;

    //    var notificationIntentData = AndroidNotificationCenter.GetLastNotificationIntent();

    //    if (notificationIntentData != null)
    //    {
    //        Debug.Log("App was opened with notification!");
    //    }

    //}

    //private void OnApplicationPause(bool pause)
    //{

    //    if (AndroidNotificationCenter.CheckScheduledNotificationStatus(identifier) == NotificationStatus.Scheduled)
    //    {
    //        //If the player has left the game and the game is not running. Send them a new notification
    //        AndroidNotification newNotification = new AndroidNotification()
    //        {
    //            Title = "Alret from COVID 20",
    //            Text = "Don't forget to Clear all the levels and win the amazon gift coupon ",
    //            SmallIcon = "app_icon_reminder",
             
    //            FireTime = System.DateTime.Now
    //        };

    //        // Replace the currently scheduled notification with a new notification.
    //        AndroidNotificationCenter.UpdateScheduledNotification(identifier, newNotification, "default_channel");
    //    }
    //    else if (AndroidNotificationCenter.CheckScheduledNotificationStatus(identifier) == NotificationStatus.Delivered)
    //    {
    //        //Remove the notification from the status bar
    //        AndroidNotificationCenter.CancelNotification(identifier);
    //    }
    //    else if (AndroidNotificationCenter.CheckScheduledNotificationStatus(identifier) == NotificationStatus.Unknown)
    //    {
    //        AndroidNotification notification = new AndroidNotification()
    //        {
    //            Title = "Alret from COVID 20",
    //            Text = "Don't forget to Clear all the levels and win the amazon gift coupon ",
    //            SmallIcon = "app_icon_reminder",
    //            FireTime = System.DateTime.Now.AddSeconds(10),
    //        };

    //        //Try sending it again
    //        identifier = AndroidNotificationCenter.SendNotification(notification, "default_channel");
    //    }


    //}

    //private void OnApplicationQuit()
    //{
    //    AndroidNotification notification = new AndroidNotification()
    //    {
    //        Title = "Alret from COVID 20",
    //        Text = "Don't forget to Clear all the levels and win the amazon gift coupon ",
    //        SmallIcon = "app_icon_reminder",
    //        FireTime = System.DateTime.Now.AddSeconds(10),
    //    };

    //    AndroidNotificationCenter.NotificationReceivedCallback receivedNotificationHandler = delegate (AndroidNotificationIntentData data)
    //    {
    //        var msg = "Notification received : " + data.Id + "\n";
    //        msg += "\n Notification received: ";
    //        msg += "\n .Title: " + data.Notification.Title;
    //        msg += "\n .Body: " + data.Notification.Text;
    //        msg += "\n .Channel: " + data.Channel;
    //        Debug.Log(msg);
    //    };
    //}
}