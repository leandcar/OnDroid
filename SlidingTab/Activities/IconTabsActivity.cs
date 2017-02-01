using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.App;
using SlidingTab.Adapters;
using SlidingTab.Fragments;
using Fragment = Android.Support.V4.App.Fragment;

namespace SlidingTab.Activities
{
    [Activity(Label = "Icon Tabs")]
    public class IconTabsActivity : AppCompatActivity
    {
        private readonly FragmentOne fragment1 = new FragmentOne();
        private readonly FragmentTwo fragment2 = new FragmentTwo();
        private readonly FragmentThree fragment3 = new FragmentThree();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.tabs_activity);

            var toolBar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolBar);

            var fragments = new Fragment[]
           {
                fragment1,
                fragment2,
                fragment3,
           };

            var viewPager = FindViewById<ViewPager>(Resource.Id.viewPager);
            viewPager.Adapter = new IconTabsFragmentPagerAdapter(SupportFragmentManager, fragments);

            var tabLayout = FindViewById<TabLayout>(Resource.Id.sliding_tabs);
            tabLayout.SetupWithViewPager(viewPager);

            tabLayout.GetTabAt(0).SetIcon(Resource.Drawable.ic_filter_1_white_24dp);
            tabLayout.GetTabAt(1).SetIcon(Resource.Drawable.ic_filter_2_white_24dp);
            tabLayout.GetTabAt(2).SetIcon(Resource.Drawable.ic_filter_3_white_24dp);
        }
    }
}