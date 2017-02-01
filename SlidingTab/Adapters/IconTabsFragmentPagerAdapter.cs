using Android.Support.V4.App;

namespace SlidingTab.Adapters
{
    public class IconTabsFragmentPagerAdapter : FragmentPagerAdapter
    {
        private readonly Fragment[] fragments;

        public IconTabsFragmentPagerAdapter(FragmentManager fm, Fragment[] fragments) : base(fm)
        {
            this.fragments = fragments;
        }
        public override int Count => fragments.Length;

        public override Fragment GetItem(int position)
        {
            return fragments[position];
        }
    }
}