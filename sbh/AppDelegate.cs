using Foundation;
using UIKit;
using Pushwoosh;
using UserNotifications;
using System;

namespace sbh
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate, IUIApplicationDelegate
    {

        [Export("window")]
        public UIWindow Window { get; set; }

        [Export("application:didFinishLaunchingWithOptions:")]
        public bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // Override point for customization after application launch.
            // If not required for your application you can safely delete this method

            PushNotificationManager pushmanager = PushNotificationManager.PushManager;
            pushmanager.Delegate = new PushDelegate();
            UNUserNotificationCenter.Current.Delegate = pushmanager.NotificationCenterDelegate;

            if (launchOptions != null)
            {
                if (launchOptions.ContainsKey(UIApplication.LaunchOptionsRemoteNotificationKey))
                {
                    pushmanager.HandlePushReceived(launchOptions);
                }
            }

            pushmanager.RegisterForPushNotifications();

            return true;
        }

        // UISceneSession Lifecycle

        [Export("application:configurationForConnectingSceneSession:options:")]
        public UISceneConfiguration GetConfiguration(UIApplication application, UISceneSession connectingSceneSession, UISceneConnectionOptions options)
        {
            // Called when a new scene session is being created.
            // Use this method to select a configuration to create the new scene with.
            return UISceneConfiguration.Create("Default Configuration", connectingSceneSession.Role);
        }

        [Export("application:didDiscardSceneSessions:")]
        public void DidDiscardSceneSessions(UIApplication application, NSSet<UISceneSession> sceneSessions)
        {
            // Called when the user discards a scene session.
            // If any sessions were discarded while the application was not running, this will be called shortly after `FinishedLaunching`.
            // Use this method to release any resources that were specific to the discarded scenes, as they will not return.
        }

        public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
        {
            PushNotificationManager.PushManager.HandlePushRegistration(deviceToken);
        }

        public override void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
        {
            PushNotificationManager.PushManager.HandlePushRegistrationFailure(error);
        }

        public override void ReceivedRemoteNotification(UIApplication application, NSDictionary userInfo)
        {
            PushNotificationManager.PushManager.HandlePushReceived(userInfo);
        }
    }

    public class PushDelegate : PushNotificationDelegate
    {
        public override void OnPushAccepted(PushNotificationManager pushManager, NSDictionary pushNotification)
        {
            Console.WriteLine("Push accepted: " + pushNotification);
        }

        public override void OnPushReceived(PushNotificationManager pushManager, NSDictionary pushNotification, bool onStart)
        {
            Console.WriteLine("Push received: " + pushNotification);
        }

        public override void OnDidRegisterForRemoteNotificationsWithDeviceToken(NSString token)
        {
            Console.WriteLine("Registered for push notifications: " + token);
        }

        public override void OnDidFailToRegisterForRemoteNotificationsWithError(NSError error)
        {
            Console.WriteLine("Error: " + error);
        }
    }
}

