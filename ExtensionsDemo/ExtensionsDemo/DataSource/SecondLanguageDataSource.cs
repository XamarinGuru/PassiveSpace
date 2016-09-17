using System;
using UIKit;
using Foundation;
using System.Collections.Generic;

namespace ExtensionsDemo
{
	public class SecondLanguageDataSource : UITableViewSource
	{
		private string[] data = {"English", "svenska", "Deutsche", "العربية", "中文", "français", "हिंदी", "italiano", "日本語", "한국어", "русский", "Español"};
		string cellIdentifier = "SecondLanguageCell";

		public SecondLanguageDataSource ()
		{
		}

		public override nint RowsInSection (UITableView tableView, nint section)
		{
			return data.Length;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			SecondLanguageCell cell = tableView.DequeueReusableCell (cellIdentifier) as SecondLanguageCell;

			var defs = new NSUserDefaults ("group.com.xamarin.ExtensionsDemo", NSUserDefaultsType.SuiteName);
			NSNumber sIndex = (NSNumber)defs.ValueForKey(new NSString("SecondLanguage"));
			if (sIndex.NIntValue == indexPath.Row) {
				cell.SetCell (data [indexPath.Row], indexPath.Row, tableView, true);
			} else {
				cell.SetCell (data[indexPath.Row], indexPath.Row, tableView, false);
			}

			return cell;
		}
	}
}

