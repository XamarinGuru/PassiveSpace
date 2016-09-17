namespace Notifications
{
    using System;

    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Support.V4.App;
    using Android.Widget;
	using Java.Lang;
    using String = System.String;


	[Activity(Label = "PassiveSpace", MainLauncher = true, Theme = "@android:style/Theme.NoTitleBar")]
	public class MainActivity : Activity
    {
		private static Intent serviceIntent = null;

		string[] arrLanguages = {"English", "svenska", "Deutsche", "العربية", "中文", "français", "हिंदी", "italiano", "日本語", "한국어", "русский", "Español"};
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

			if (serviceIntent == null) {
				serviceIntent = new Intent(this, typeof(SimpleService));
				StartService(serviceIntent);
			}

			ISharedPreferences prefs = Application.Context.GetSharedPreferences ("LanguageInfo", FileCreationMode.Private);
			ISharedPreferencesEditor editor = prefs.Edit();

			int nFirstLanguage = prefs.GetInt ("FirstLanguage", 0);
			int nSecondLanguage = prefs.GetInt ("SecondLanguage", 1);

			Button btnSecondLanguage = FindViewById<Button> (Resource.Id.btnGoToSecondLanguage);
			string strBtnTitle = string.Format("{0} >", arrLanguages[nFirstLanguage]);
			btnSecondLanguage.Text = strBtnTitle;

			RadioGroup radioGroup = FindViewById<RadioGroup> (Resource.Id.MainLanguageGroup);
			radioGroup.ClearCheck ();
			RadioButton button = radioGroup.GetChildAt(nSecondLanguage) as RadioButton;
			button.Checked = true;

			radioGroup.CheckedChange += (object sender, RadioGroup.CheckedChangeEventArgs e) => {
				RadioButton checkedRadioButton = FindViewById<RadioButton>(radioGroup.CheckedRadioButtonId);
				int buttonIndex = radioGroup.IndexOfChild(checkedRadioButton);

				editor.PutInt("SecondLanguage" ,buttonIndex);
				editor.Apply();

				if (serviceIntent == null) {
					serviceIntent = new Intent(this, typeof(SimpleService));
					StartService(serviceIntent);
				}

				Console.WriteLine("{0}", buttonIndex);
			};

			btnSecondLanguage.Click += delegate {
				var activity2 = new Intent (this, typeof(SecondActivity));
				StartActivity (activity2);
			};
        }
			
    }
}
