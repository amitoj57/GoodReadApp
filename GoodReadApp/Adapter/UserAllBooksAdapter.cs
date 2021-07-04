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
    public class UserAllBooksAdapter : BaseAdapter<Book>
    {
        private readonly Activity context;
        private readonly List<Book> books;

        public UserAllBooksAdapter(Activity context, List<Book> books)
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
                row = LayoutInflater.From(context).Inflate(Resource.Layout.list_user_book_row, null, false); ;
            }

            TextView txt1 = row.FindViewById<TextView>(Resource.Id.text1);
            TextView txt2 = row.FindViewById<TextView>(Resource.Id.text2);
            TextView txt3 = row.FindViewById<TextView>(Resource.Id.text3);
            TextView txt4 = row.FindViewById<TextView>(Resource.Id.text4);

            Book book = books[position];
            txt1.Text = "Book Title: " + book.BookName;
            txt2.Text = "Authors: " + book.Authors;
            txt3.Text = "Pages: " + book.Pages;
            txt4.Text = "Description: " + book.Description;


            return row;
        }
    }
}