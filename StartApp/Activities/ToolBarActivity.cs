using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace StartApp.Activities
{
    [Activity(Label = "ToolBar Activity", MainLauncher = true)]
    public class ToolBarActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.tool_bar_activity);
        }
    }
}