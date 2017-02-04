using System.Collections.Generic;
using System.IO;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using Monkeys.Data;

namespace Monkeys.Adapters
{
	public class MonkeyAdapter : BaseAdapter<Monkey>
	{
	    private readonly List<Monkey> monkeys;

		public MonkeyAdapter(List<Monkey> monkeys)
		{
			this.monkeys = monkeys;
		}

		public override Monkey this[int position] => monkeys[position];

	    public override int Count => monkeys.Count;

	    public override long GetItemId(int position) => position;

	    public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var inflater = LayoutInflater.From(parent.Context);
			var view = inflater.Inflate(Resource.Layout.list_item, parent, false);

		    var image = view.FindViewById<ImageView>(Resource.Id.photoImageView);
		    var name = view.FindViewById<TextView>(Resource.Id.nameTextView);
		    var location = view.FindViewById<TextView>(Resource.Id.locationTextView);

		    Stream stream = parent.Context.Assets.Open("Images/" + monkeys[position].Image);
			Drawable drawable = Drawable.CreateFromStream(stream, null);
			image.SetImageDrawable(drawable);

		    name.Text = monkeys[position].Name;
		    location.Text = monkeys[position].Location;

			return view;
		}
	}
}