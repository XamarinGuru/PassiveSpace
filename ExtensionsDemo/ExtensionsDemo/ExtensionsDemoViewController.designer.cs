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

namespace ExtensionsDemo
{
	[Register ("ExtensionsDemoViewController")]
	partial class ExtensionsDemoViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblSelectedLanguage { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView tvSecondLanguages { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (lblSelectedLanguage != null) {
				lblSelectedLanguage.Dispose ();
				lblSelectedLanguage = null;
			}
			if (tvSecondLanguages != null) {
				tvSecondLanguages.Dispose ();
				tvSecondLanguages = null;
			}
		}
	}
}
