using System;
using UIKit;
using Foundation;
using System.Collections.Generic;

namespace ExtensionsDemo
{
	public class MainLanguageDataSource : UITableViewSource
	{
		private UIViewController owner;
		private string[] data = {"English", "svenska", "Deutsche", "العربية", "中文", "français", "हिंदी", "italiano", "日本語", "한국어", "русский", "Español"};
		string cellIdentifier = "MainLanguageCell";

		public MainLanguageDataSource (UIViewController super)
		{
			owner = super;
		}

		public override nint RowsInSection (UITableView tableView, nint section)
		{
			return data.Length;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			MainLanguageCell cell = tableView.DequeueReusableCell (cellIdentifier) as MainLanguageCell;
			cell.SetCell (data[indexPath.Row]);

			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var defs = new NSUserDefaults ("group.com.xamarin.ExtensionsDemo", NSUserDefaultsType.SuiteName);
			defs.SetInt(indexPath.Row, "MainLanguage");
			defs.Synchronize ();

			owner.NavigationController.PopViewController (true);
		}
	}
}

