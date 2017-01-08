using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace StartApp.Activities
{
    [Activity(Label = "Basic Activity", MainLauncher = true, Theme = "@style/AppTheme.NoActionBar")]
    public class BasicActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.basic_activity);
        }
    }
}