// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace EvolveCountdownWidget
{
	[Register ("EvolveCountdownViewController")]
	partial class EvolveCountdownViewController
	{
		[Outlet]
		UIKit.UILabel WidgetTitle { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnFirst { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnIcon { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnSecond { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView imgThumb { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (btnFirst != null) {
				btnFirst.Dispose ();
				btnFirst = null;
			}
			if (btnIcon != null) {
				btnIcon.Dispose ();
				btnIcon = null;
			}
			if (btnSecond != null) {
				btnSecond.Dispose ();
				btnSecond = null;
			}
			if (imgThumb != null) {
				imgThumb.Dispose ();
				imgThumb = null;
			}
		}
	}
}
