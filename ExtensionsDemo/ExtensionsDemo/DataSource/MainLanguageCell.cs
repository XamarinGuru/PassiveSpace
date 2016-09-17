using System;

using Foundation;
using UIKit;

namespace ExtensionsDemo
{
	public partial class MainLanguageCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("MainLanguageCell");
		public static readonly UINib Nib;

		static MainLanguageCell ()
		{
			Nib = UINib.FromName ("MainLanguageCell", NSBundle.MainBundle);
		}

		public MainLanguageCell (IntPtr handle) : base (handle)
		{
		}

		public void SetCell(string title)
		{
			lblTitle.Text = title;
		}
	}
}
