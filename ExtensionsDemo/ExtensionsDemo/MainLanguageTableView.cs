using System;

using UIKit;

namespace ExtensionsDemo
{
	public partial class MainLanguageTableView : UITableViewController
	{
		public MainLanguageTableView (IntPtr handle) : base (handle)
		{

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			TableView.Source = new MainLanguageDataSource (this);
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


