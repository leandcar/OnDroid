using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Burguer.Fragments;
using Fragment = Android.Support.V4.App.Fragment;

namespace Burguer.Activities
{
    [Activity(Label = "Burguer", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private DrawerLayout drawerLayout;

        private TextView nomeTextView;
        private TextView emailTextView;

        private readonly Fragment1 fragment1 = new Fragment1();
        private readonly Fragment2 fragment2 = new Fragment2();
        private readonly Fragment3 fragment3 = new Fragment3();
        private readonly Fragment4 fragment4 = new Fragment4();

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
            navigationView.NavigationItemSelected += NavigationItemSelected;

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

        private void NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            drawerLayout.CloseDrawer(GravityCompat.Start);

            Fragment fragment;
            switch (e.MenuItem.ItemId)
            {
                case Resource.Id.nav_one:
                    fragment = fragment1;
                    break;
                case Resource.Id.nav_two:
                    fragment = fragment2;
                    break;
                case Resource.Id.nav_three:
                    fragment = fragment3;
                    break;
                case Resource.Id.nav_four:
                    fragment = fragment4;
                    break;
                default:
                    return;
            }

            var trans = SupportFragmentManager.BeginTransaction();
            trans.Replace(Resource.Id.contentFrame, fragment);
            trans.Commit();
        }
    }
}