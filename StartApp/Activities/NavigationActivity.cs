using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;

namespace StartApp.Activities
{
    [Activity]
    public class NavigationActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.navigation_activity);

            var toolBar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolBar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            Title = "Navigation";
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    //OverridePendingTransition(Resource.Animation.slide_in_right, Resource.Animation.slide_out_left);
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        public override void Finish()
        {
            base.Finish();

            OverridePendingTransition(Resource.Animation.slide_in_right, Resource.Animation.slide_out_left);
        }
    }
}