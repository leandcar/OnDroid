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
    [Activity(Label = "Toolbar Activity", MainLauncher = true)]
    public class ToolbarActivity : AppCompatActivity
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
                    return true;

                case Resource.Id.add_menu:
                    return true;

                case Resource.Id.browser_menu:
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        private void ShowToast()
        {
            Toast.MakeText(this, "Isto é um Toast.", ToastLength.Long).Show();
        }

        private void ShowSnackbar()
        {
            Snackbar.Make(rootLayout, "Isto é um Snackbar.", Snackbar.LengthIndefinite)
                    .SetAction("OK", (v) => { })
                    .Show();
        }

        private void ShowAlertDialog()
        {
            var builder = new AlertDialog.Builder(this);

            builder.SetTitle("Material Design")
                   .SetMessage("Isto é um AlertDialog")
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

        private void NextButtonOnClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(BasicActivity));
            StartActivity(intent);
        }
    }
}