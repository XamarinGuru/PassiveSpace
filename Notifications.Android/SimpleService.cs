using System;
using Android.App;
using Android.Util;
using System.Threading;
using Android.Content;
using Android.OS;
using Android.Widget;
using System.Text.RegularExpressions;
using Android.Content.Res;
using Android.Preferences;
using System.IO;

namespace Notifications
{
    [Service]
    public class SimpleService : Service
    {
        System.Threading.Timer _timer;

		[Android.Runtime.Register("onStart", "(Landroid/content/Intent;I)V", "GetOnStart_Landroid_content_Intent_IHandler")]
		[System.Obsolete("deprecated")]
        
		public override void OnStart (Android.Content.Intent intent, int startId)
        {
            base.OnStart (intent, startId);

            DoStuff ();
        }
        
        public override void OnDestroy ()
        {
            base.OnDestroy ();
            
            _timer.Dispose ();
            
            Log.Debug ("SimpleService", "SimpleService stopped");       
        }

        public void DoStuff ()
        {
            _timer = new System.Threading.Timer ((o) => {
                Log.Debug ("Notifications", "hello from simple service");
				FireNotification ();
			}, null, 0, 1000*3600*4);
        }

        public override Android.OS.IBinder OnBind (Android.Content.Intent intent)
        {
            throw new NotImplementedException ();
        }

		public void FireNotification ()
		{
			ISharedPreferences prefs = Application.Context.GetSharedPreferences ("LanguageInfo", FileCreationMode.Private);

			int nFirstLanguage = prefs.GetInt ("FirstLanguage", 0);
			int nSecondLanguage = prefs.GetInt ("SecondLanguage", 1);

			// Build the notification
			Random randl = new Random ();

			AssetManager assets = this.Assets;
			String content;
			char[] newlineSeparator = new char[] {'\n'};

			using (StreamReader sr = new StreamReader (assets.Open ("PassiveDB.csv")))
			{
				content = sr.ReadToEnd ();
			}
			var items = content.Split(newlineSeparator);

			string item = items[randl.Next(2266)];

			char[] comma = new char[] {','};
			var arrItem = item.Split (comma);

			Notification.Builder builder = new Notification.Builder (this)
				.SetContentTitle (arrItem[nFirstLanguage])
				.SetContentText (arrItem[nSecondLanguage])
				.SetSmallIcon (Resource.Drawable.appicon);

			builder.SetDefaults (NotificationDefaults.Sound | NotificationDefaults.Vibrate);
			builder.SetVisibility (NotificationVisibility.Public);

			// Build the notification:
			Notification notification = builder.Build();

			// Get the notification manager:
			NotificationManager notificationManager =
				GetSystemService (Context.NotificationService) as NotificationManager;

			// Publish the notification:
			const int notificationId = 0;
			notificationManager.Notify (notificationId, notification);
		}
	}
}