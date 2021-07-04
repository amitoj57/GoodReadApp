using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using GoodReadApp.Adapter;
using GoodReadApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoodReadApp
{
    [Activity(Label = "Delete Book")]
    public class DeleteBookActivity : AppCompatActivity
    {
        Button b1, b2;
        Spinner spinner;
        string username;
        DataSource dataSource;
        BookSpinnerAdapter adapter;
        List<Book> books;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_delete_book);

            dataSource = new DataSource();
            spinner = FindViewById<Spinner>(Resource.Id.spinner);
            b1 = FindViewById<Button>(Resource.Id.b1);
            b2 = FindViewById<Button>(Resource.Id.b2);

            books = dataSource.GetAllBooks();
            adapter = new BookSpinnerAdapter(this, books);
            spinner.Adapter = adapter;

            b1.Click += B1_Click;
            b2.Click += B2_Click;
        }

        private void B2_Click(object sender, EventArgs e)
        {
            Finish();
        }

        private void B1_Click(object sender, EventArgs e)
        {
            string message = "";
            if (books != null && books.Count() > 0)
            {
                Book book = books[spinner.SelectedItemPosition];
                if (dataSource.DeleteBook(book))
                {
                    message = "Book Details is Removed";
                    books.RemoveAt(spinner.SelectedItemPosition);
                    adapter.NotifyDataSetChanged();
                }
                else
                {
                    message = "Book Details in not Removed";
                }
            }
            else
            {
                message = "There is No Book Available For Delete.";
            }
            Toast.MakeText(this, message, ToastLength.Long).Show();
        }
    }
}