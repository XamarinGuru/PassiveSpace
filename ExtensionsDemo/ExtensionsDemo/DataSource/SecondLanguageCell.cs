using System;

using Foundation;
using UIKit;

namespace ExtensionsDemo
{
	public partial class SecondLanguageCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("SecondLanguageCell");
		public static readonly UINib Nib;

		private int lIndex;
		private UITableView owner;

		static SecondLanguageCell ()
		{
			Nib = UINib.FromName ("SecondLanguageCell", NSBundle.MainBundle);
		}

		public SecondLanguageCell (IntPtr handle) : base (handle)
		{
		}

		public void SetCell(string title, int index, UITableView super, bool state)
		{
			lIndex = index;
			owner = super;

			lblTitle.Text = title;

			switchLanguage.SetState(state, true);
			switchLanguage.ValueChanged -= SetSecondLanguage;
			switchLanguage.ValueChanged += SetSecondLanguage;
		}

		void SetSecondLanguage (object sender, EventArgs e)
        {
			var defs = new NSUserDefaults ("group.com.xamarin.ExtensionsDemo", NSUserDefaultsType.SuiteName);

			defs.SetValueForKey(new NSNumber(lIndex), new NSString("SecondLanguage"));
			defs.Synchronize ();

			owner.ReloadData ();
        }
	}
}
