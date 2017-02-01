using Android.OS;
using Android.Views;
using Android.Widget;
using Fragment = Android.Support.V4.App.Fragment;

namespace SlidingTab.Fragments
{
    public class FragmentOne : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            var view = inflater.Inflate(Resource.Layout.fragment_layout, container, false);

            var info = view.FindViewById<TextView>(Resource.Id.fragmentName);
            info.Text = "Fragment One";

            return view;
        }
    }
}