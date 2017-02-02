using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Graphics.Drawable;
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

            //tabLayout.GetTabAt(0).SetIcon(Resource.Drawable.ic_filter_1_white_24dp);
            //tabLayout.GetTabAt(1).SetIcon(Resource.Drawable.ic_filter_2_white_24dp);
            //tabLayout.GetTabAt(2).SetIcon(Resource.Drawable.ic_filter_3_white_24dp);

            var tabIconColors = Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop
                        ? Resources.GetColorStateList(Resource.Drawable.tab_icon_color, Theme)
                        : Resources.GetColorStateList(Resource.Drawable.tab_icon_color);

            var icon1 = GetDrawable(Resource.Drawable.ic_filter_1_white_24dp);
            var icon2 = GetDrawable(Resource.Drawable.ic_filter_2_white_24dp);
            var icon3 = GetDrawable(Resource.Drawable.ic_filter_3_white_24dp);

            var tab1 = tabLayout.GetTabAt(0);
            var tab2 = tabLayout.GetTabAt(1);
            var tab3 = tabLayout.GetTabAt(2);

            // We wrap the icon to support API < 21
            var iconWrap = DrawableCompat.Wrap(icon1);
            DrawableCompat.SetTintList(iconWrap, tabIconColors);
            tab1.SetIcon(iconWrap);

            iconWrap = DrawableCompat.Wrap(icon2);
            DrawableCompat.SetTintList(iconWrap, tabIconColors);
            tab2.SetIcon(iconWrap);

            iconWrap = DrawableCompat.Wrap(icon3);
            DrawableCompat.SetTintList(iconWrap, tabIconColors);
            tab3.SetIcon(iconWrap);
        }
    }
}