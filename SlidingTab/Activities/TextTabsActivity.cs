using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.App;
using SlidingTab.Adapters;
using SlidingTab.Fragments;
using Fragment = Android.Support.V4.App.Fragment;

namespace SlidingTab.Activities
{
    [Activity(Label = "Text Tabs")]
    public class TextTabsActivity : AppCompatActivity
    {
        private readonly FragmentOne fragment1 = new FragmentOne();
        private readonly FragmentTwo fragment2 = new FragmentTwo();
        private readonly FragmentThree fragment3 = new FragmentThree();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.text_tabs_activity);

            var toolBar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolBar);

            var fragments = new Fragment[]
           {
                fragment1,
                fragment2,
                fragment3,
           };

            var titles = CharSequence.ArrayFromStringArray(new[]
            {
                "Tab One",
                "Tab Two",
                "Tab Three"
            });

            var viewPager = FindViewById<ViewPager>(Resource.Id.viewPager);
            viewPager.Adapter = new TextTabsFragmentPagerAdapter(SupportFragmentManager, fragments, titles);

            var tabLayout = FindViewById<TabLayout>(Resource.Id.sliding_tabs);
            tabLayout.SetupWithViewPager(viewPager);
        }
    }
}