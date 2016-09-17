using System;
using System.Drawing;

using Foundation;
using UIKit;
using NotificationCenter;
using WebKit;
using FlexCel.Core;
using FlexCel.XlsAdapter;

namespace ExtensionsDemo
{
	public partial class ExtensionsDemoViewController : UIViewController
	{
		private string[] languageData = {"English", "svenska", "Deutsche", "العربية", "中文", "français", "हिंदी", "italiano", "日本語", "한국어", "русский", "Español"};

		public ExtensionsDemoViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			var defs = new NSUserDefaults ("group.com.xamarin.ExtensionsDemo", NSUserDefaultsType.SuiteName);

			NSNumber mIndex = (NSNumber)defs.ValueForKey(new NSString("MainLanguage"));

			lblSelectedLanguage.Text = string.Format("{0} >", languageData [mIndex.NIntValue]);

			var controller = NCWidgetController.GetWidgetController ();
            controller.SetHasContent (true, "com.xamarin.ExtensionsDemo.EvolveCountdownWidget");

			tvSecondLanguages.Source = new SecondLanguageDataSource ();
		}

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();

			var defs = new NSUserDefaults ("group.com.xamarin.ExtensionsDemo", NSUserDefaultsType.SuiteName);

			NSNumber mIndex = (NSNumber)defs.ValueForKey(new NSString("MainLanguage"));
			if (mIndex == null) {
				defs.SetValueForKey(new NSNumber(0), new NSString("MainLanguage"));
				defs.Synchronize ();
			}

			NSNumber sIndex = (NSNumber)defs.ValueForKey(new NSString("SecondLanguage"));
			if (sIndex == null) {
				defs.SetValueForKey(new NSNumber(1), new NSString("SecondLanguage"));
				defs.Synchronize ();
			}
        }
	}
}

