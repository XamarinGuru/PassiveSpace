using System;
using System.Linq;
using System.Collections.Generic;

using Foundation;
using UIKit;

using System.Threading;
using System.Threading.Tasks;

using FlexCel.Core;
using FlexCel.XlsAdapter;

using System.Drawing;
using NotificationCenter;
using Social;
using CoreGraphics;

namespace ExtensionsDemo
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations

		private nint bgThread = -1;

		public override UIWindow Window {
			get;
			set;
		}

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			var notificationSettings = UIUserNotificationSettings.GetSettingsForTypes (
				UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null
			);

			application.RegisterUserNotificationSettings (notificationSettings);

			UIApplication.SharedApplication.SetMinimumBackgroundFetchInterval (UIApplication.BackgroundFetchIntervalMinimum);


			return true;
		}

		public override void OnResignActivation (UIApplication application)
		{
		}

		public override void DidEnterBackground (UIApplication application)
		{
			if (bgThread == -1) {
				bgThread = UIApplication.SharedApplication.BeginBackgroundTask( () => {});
				new Task ( () => {
					Timer timer = new Timer (ttimerCallback, null, TimeSpan.FromSeconds (0), TimeSpan.FromSeconds (3600*4));
				}).Start();
			}
		}
		private void ttimerCallback(object state){

			InvokeOnMainThread(async () => { await GetReservationVehicleLocations(); });
		}

		private async Task GetReservationVehicleLocations()
		{
			var notification = new UILocalNotification();

			var defs = new NSUserDefaults ("group.com.xamarin.ExtensionsDemo", NSUserDefaultsType.SuiteName);

			NSNumber mIndex = (NSNumber)defs.ValueForKey(new NSString("MainLanguage"));
			NSNumber sIndex = (NSNumber)defs.ValueForKey(new NSString("SecondLanguage"));

			Random rand = new Random ();
			int rIndex = rand.Next (2266);

			XlsFile xls = new XlsFile(true);
			xls.Open ("PassiveDB.xls");

			notification.AlertAction = "go to PassiveSpace";
			notification.AlertTitle = xls.GetCellValue (rIndex, (int)mIndex.NIntValue+1).ToString ();
			notification.AlertBody = string.Format("{0} : {1}", xls.GetCellValue (rIndex, (int)mIndex.NIntValue+1).ToString (), xls.GetCellValue (rIndex, (int)sIndex.NIntValue+1).ToString ());
			notification.AlertLaunchImage = "icon.png";

			// set the sound to be the default sound
			notification.SoundName = UILocalNotification.DefaultSoundName;

			// schedule it
			UIApplication.SharedApplication.ScheduleLocalNotification(notification);
		}

		// This method is called as part of the transiton from background to active state.
		public override void WillEnterForeground (UIApplication application)
		{
		}

		// This method is called when the application is about to terminate. Save data, if needed.
		public override void WillTerminate (UIApplication application)
		{
			if (bgThread != -1) {
				UIApplication.SharedApplication.EndBackgroundTask(bgThread);
			}
		}
	}
}

