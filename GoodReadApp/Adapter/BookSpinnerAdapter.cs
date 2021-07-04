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
    class BookSpinnerAdapter : BaseAdapter<Book>
    {
        private readonly Activity context;
        private readonly List<Book> books;

        public BookSpinnerAdapter(Activity context, List<Book> books)
        {
            this.books = books;
            this.context = context;
        }

        public override int Count
        {
            get { return books.Count; }

        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Book this[int position]
        {
            get { return books[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.list_user_row, null, false);
            }

            TextView txt1 = row.FindViewById<TextView>(Resource.Id.text1);

            txt1.Text = books[position].BookName + " (" + books[position].Authors + ")";

            return row;
        }
    }
}