using Android.OS;
using Android.Support.V4.App;
using Android.Views;

namespace Burguer.Fragments
{
    public class Fragment1 : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.fragment_one, container, false);
        }
    }
}