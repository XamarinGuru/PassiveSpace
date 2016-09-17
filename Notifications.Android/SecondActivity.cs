using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;

namespace Notifications
{
	[Activity (Label = "SecondActivity", Theme = "@android:style/Theme.NoTitleBar")]			
	public class SecondActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView(Resource.Layout.Second);

			ISharedPreferences prefs = Application.Context.GetSharedPreferences ("LanguageInfo", FileCreationMode.Private);
			ISharedPreferencesEditor editor = prefs.Edit();

			int nFirstLanguage = prefs.GetInt ("FirstLanguage", 0);

			RadioGroup radioGroup = FindViewById<RadioGroup> (Resource.Id.SecondGroup);
			radioGroup.ClearCheck ();
			RadioButton button = radioGroup.GetChildAt(nFirstLanguage) as RadioButton;
			button.Checked = true;

			radioGroup.CheckedChange += (object sender, RadioGroup.CheckedChangeEventArgs e) => {
				RadioButton checkedRadioButton = FindViewById<RadioButton>(radioGroup.CheckedRadioButtonId);
				int buttonIndex = radioGroup.IndexOfChild(checkedRadioButton);

				prefs = Application.Context.GetSharedPreferences ("LanguageInfo", FileCreationMode.Private);
				editor = prefs.Edit();
				editor.PutInt("FirstLanguage" ,buttonIndex);
				editor.Apply();

				var MainActivity = new Intent (this, typeof(MainActivity));
				StartActivity (MainActivity);

				Console.WriteLine("{0}", buttonIndex);
			};

			ImageButton btnBack = FindViewById<ImageButton> (Resource.Id.btnBack);

			btnBack.Click += delegate {
				var MainActivity = new Intent (this, typeof(MainActivity));
				StartActivity (MainActivity);
			};
		}
	}
}

