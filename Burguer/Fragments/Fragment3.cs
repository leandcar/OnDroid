using Android.OS;
using Android.Views;
using Fragment = Android.Support.V4.App.Fragment;

namespace Burguer.Fragments
{
    public class Fragment3 : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.fragment_three, container, false);
        }
    }
}