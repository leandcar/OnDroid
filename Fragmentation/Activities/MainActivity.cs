using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace Fragmentation.Activities
{
    [Activity(Label = "Fragmentation", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.main_activity);

            var toolBar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolBar);
        }
    }
}