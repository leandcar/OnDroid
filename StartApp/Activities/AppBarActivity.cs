using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using AlertDialog = Android.Support.V7.App.AlertDialog;

namespace StartApp.Activities
{
    // https://material.io/guidelines/layout/structure.html#structure-app-bar
    // https://developer.android.com/training/appbar/index.html
    [Activity(Label = "StartApp", MainLauncher = true)]
    public class AppBarActivity : AppCompatActivity
    {
        private RelativeLayout rootLayout;
        private Button nextButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.tool_bar_activity);

            rootLayout = FindViewById<RelativeLayout>(Resource.Id.RootLayout);

            nextButton = FindViewById<Button>(Resource.Id.nextButton);
            nextButton.Click += NextButtonOnClick;

            var toolBar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolBar);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.toolbar_menu, menu);
            return true;
        }

        // https://material.io/guidelines/components/snackbars-toasts.html
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.toast_menu:
                    ShowToast();
                    return true;

                case Resource.Id.snackbar_menu:
                    ShowSnackbar();
                    return true;

                case Resource.Id.alert_dialog_menu:
                    ShowAlertDialog();
                    return true;

                case Resource.Id.navigation_menu:
                    GoToNavigationActivity();
                    return true;

                case Resource.Id.browser_menu:
                    OpenImplicit();
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        // https://developer.android.com/guide/topics/ui/notifiers/toasts.html
        private void ShowToast()
        {
            Toast.MakeText(this, "Isto é um Toast.", ToastLength.Long).Show();
        }

        // https://developer.android.com/training/snackbar/index.html
        private void ShowSnackbar()
        {
            Snackbar.Make(rootLayout, "Isto é um Snackbar.", Snackbar.LengthIndefinite)
                    .SetAction("OK", (v) => { })
                    .Show();
        }

        private void ShowAlertDialog()
        {
            var builder = new AlertDialog.Builder(this);

            // There are two types of Alert Dialogs
            // https://material.io/guidelines/components/dialogs.html#dialogs-behavior
            // 1 - Alerts without title bars
            // 2 - Alerts with title bars
            // To remove the the Title Bar -> Remove the line: .SetTitle()
            builder.SetMessage("Isto é um AlertDialog")
                   .SetTitle("Material Design")
                   .SetPositiveButton("Positive", (o, args) => {
                       Snackbar.Make(rootLayout, "Positive: Selected.", Snackbar.LengthShort).Show();
                   })
                   .SetNegativeButton("Negative", (o, args) => {
                       Snackbar.Make(rootLayout, "Negative: Selected.", Snackbar.LengthShort).Show();
                   })
                   .SetNeutralButton("Neutral", NeutralSnackBar);

            builder.Create().Show();
        }

        private void NeutralSnackBar(object sender, DialogClickEventArgs e)
        {
            Snackbar.Make(rootLayout, "Neutral: Selected.", Snackbar.LengthShort).Show();
        }

        // https://developer.android.com/guide/components/intents-filters.html
        // Explicity Intent
        private void NextButtonOnClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(BasicActivity));
            StartActivity(intent);
        }

        private void GoToNavigationActivity()
        {
            
            var intent = new Intent(this, typeof(NavigationActivity));
            StartActivity(intent);

            OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
        }

        // Implicit Intents
        // https://developer.android.com/guide/components/intents-common.html
        private void OpenImplicit()
        {
            var intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("http://www.xamarin.com/"));

            //var intent = new Intent();

            // Opening a Web Page
            //intent.SetAction(Intent.ActionView);
            //intent.SetData(Android.Net.Uri.Parse("https://www.meetup.com/pt-BR/Developers-SP/"));

            //// Launching Phone Dialer
            //var uri = Android.Net.Uri.Parse("tel:1122334455");
            //intent = new Intent(Intent.ActionDial, uri);

            //// Launching Maps
            //var uri = Android.Net.Uri.Parse("geo:-23.610472,-46.696798?z=16");
            //intent = new Intent(Intent.ActionView, uri);

            if (intent.ResolveActivity(PackageManager) != null)
                StartActivity(intent);
        }
    }
}