using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Burguer.Activities
{
    [Activity(Label = "Burguer", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private DrawerLayout drawerLayout;

        private TextView nomeTextView;
        private TextView emailTextView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.main_activity);

            var toolBar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolBar);

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);

            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawerLayout, toolBar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawerLayout.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.navigationView);

            // Define HeaderView contents
            View headerView = navigationView.GetHeaderView(0);

            nomeTextView = headerView.FindViewById<TextView>(Resource.Id.nomeTextView);
            nomeTextView.Text = "User Name";
            emailTextView = headerView.FindViewById<TextView>(Resource.Id.emailTextView);
            emailTextView.Text = "android@google.com";
        }

        public override void OnBackPressed()
        {
            if (drawerLayout.IsDrawerOpen(GravityCompat.Start))
            {
                drawerLayout.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }
    }
}