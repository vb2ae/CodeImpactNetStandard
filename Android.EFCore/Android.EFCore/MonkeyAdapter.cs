using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.EFCore.Entity;

namespace Android.EFCore
{
    public class MonkeyAdapter : BaseAdapter<Monkey>
    {
        private readonly List<Monkey> data;
        private readonly Activity context;

        public MonkeyAdapter(Activity activity, IEnumerable<Monkey> monkeys)

        {

            data = monkeys.OrderBy(s => s.id).ToList();

            context = activity;

        }



        public override long GetItemId(int position)
        {
            return position;
        }



        public override Monkey this[int position]
        {
            get { return data[position]; }
        }



        public override int Count
        {
            get { return data.Count; }
        }


        public override View GetView(int position, View convertView, ViewGroup parent)
        {
           var view = convertView;
           if (view == null)
            {
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            }



            var monkey = data[position];

            var text = view.FindViewById<TextView>(Android.Resource.Id.Text1);

            text.Text = monkey.monkeyType;

            return view;
        }

    }
}