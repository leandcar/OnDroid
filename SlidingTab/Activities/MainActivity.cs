using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;

namespace SlidingTab.Activities
{
    [Activity(Label = "Sliding Tab", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button textTabsButton;
        private Button iconTabsButton;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.main_activity);

            var toolBar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolBar);

            textTabsButton = FindViewById<Button>(Resource.Id.buttonTextTab);
            textTabsButton.Click += TextTabsButtonOnClick;

            iconTabsButton = FindViewById<Button>(Resource.Id.buttonIconTab);
            iconTabsButton.Click += IconTabsButtonOnClick;
        }

        private void TextTabsButtonOnClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(TextTabsActivity));
            StartActivity(intent);
        }

        private void IconTabsButtonOnClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(IconTabsActivity));
            StartActivity(intent);
        }
    }
}