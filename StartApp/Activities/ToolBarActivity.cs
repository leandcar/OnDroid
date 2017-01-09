using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;

namespace StartApp.Activities
{
    [Activity(Label = "Toolbar Activity", MainLauncher = true)]
    public class ToolbarActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.tool_bar_activity);

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
                case Resource.Id.snackbar_menu:
                    return true;

                case Resource.Id.alert_dialog_menu:
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
    }
}