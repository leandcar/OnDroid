using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Monkeys.Adapters;
using Monkeys.Data;

namespace Monkeys.Activities
{
    [Activity(Label = "Monkeys", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.main_activity);

            var toolBar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolBar);

            var monkeysList = FindViewById<ListView>(Resource.Id.monkeysListView);
            monkeysList.Adapter = new MonkeyAdapter(MonkeyData.Monkeys);
        }
    }
}