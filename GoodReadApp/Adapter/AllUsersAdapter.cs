using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GoodReadApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoodReadApp.Adapter
{
    public class AllUsersAdapter : BaseAdapter<Login>
    {
        private readonly Activity context;
        private readonly List<Login> users;

        public AllUsersAdapter(Activity context, List<Login> users)
        {
            this.users = users;
            this.context = context;
        }

        public override int Count
        {
            get { return users.Count; }

        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Login this[int position]
        {
            get { return users[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.list_user_row, null, false);
            }

            TextView txt1 = row.FindViewById<TextView>(Resource.Id.text1);

            txt1.Text = users[position].UserName;

            return row;
        }
    }
}