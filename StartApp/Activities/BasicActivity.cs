using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;

namespace StartApp.Activities
{
    [Activity(Label = "Basic Activity")]
    public class BasicActivity : AppCompatActivity
    {
        private Button backButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.basic_activity);

            backButton = FindViewById<Button>(Resource.Id.backButton);
            backButton.Click += (sender, args) => { Finish(); };
        }
    }
}