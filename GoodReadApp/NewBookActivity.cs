using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using GoodReadApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoodReadApp
{
    [Activity(Label = "New Book")]
    public class NewBookActivity : AppCompatActivity
    {
        EditText et1, et2,et3,et4;
        Button b1, b2;
        DataSource dataSource;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_new_book);
            dataSource = new DataSource();
            et1 = FindViewById<EditText>(Resource.Id.text1);
            et2 = FindViewById<EditText>(Resource.Id.text2);
            et3 = FindViewById<EditText>(Resource.Id.text3);
            et4 = FindViewById<EditText>(Resource.Id.text4);

            b1 = FindViewById<Button>(Resource.Id.b1);
            b2 = FindViewById<Button>(Resource.Id.b2);
            b1.Click += B1_Click;
            b2.Click += B2_Click;
        }
        private void B2_Click(object sender, EventArgs e)
        {
            Finish();
        }

        private void B1_Click(object sender, EventArgs e)
        {
            string bookname = et1.Text.Trim();
            string description = et2.Text.Trim();
            string authors = et3.Text.Trim();
            string pages = et4.Text.Trim();
            string message = "";
            if (bookname.Length == 0 || description.Length == 0 || authors.Length == 0 || pages.Length == 0)
            {
                message = "Please Enter Some Value in Boxes";
            }
            else
            {
                try
                {
                    Book book = new Book();
                    book.BookName = bookname;
                    book.Description = description;
                    book.Authors = authors;
                    book.Pages = int.Parse(pages);
                    if (dataSource.AddNewBook(book))
                    {
                        message = "New Book is Saved";
                        et1.Text = "";
                        et2.Text = "";
                        et3.Text = "";
                        et4.Text = "";
                    }
                    else
                    {
                        message = dataSource.ErrorMessage;
                    }
                }
                catch(Exception ex)
                {
                    message = "Please Enter Number in Pages Box";
                }
            }
            Toast.MakeText(this, message, ToastLength.Long).Show();
        }
    }
}