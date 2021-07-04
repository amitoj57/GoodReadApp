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
    public class BookRatingAdapter : BaseAdapter<Rating>
    {
        private readonly Activity context;
        private readonly List<Rating> ratings;

        public BookRatingAdapter(Activity context, List<Rating> ratings)
        {
            this.ratings = ratings;
            this.context = context;
        }

        public override int Count
        {
            get { return ratings.Count; }

        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Rating this[int position]
        {
            get { return ratings[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.list_rating_row, null, false); ;
            }

            TextView txt1 = row.FindViewById<TextView>(Resource.Id.text1);
            TextView txt2 = row.FindViewById<TextView>(Resource.Id.text2);

            Rating rating = ratings[position];
            txt1.Text = "Book Title: " + rating.BookName;
            txt2.Text = "Rating: " + rating.Star;
            return row;
        }
    }
}