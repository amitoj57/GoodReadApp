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
    [Activity(Label = "Give Book Rating")]
    public class AddBookRatingActivity : AppCompatActivity
    {
        Button b1, b2;
        Spinner spinner;
        EditText et1;
        string username;
        DataSource dataSource;
        BookSpinnerAdapter adapter;
        List<Book> books;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_add_book_rating);
            username = Intent.GetStringExtra("UserName"); 
            dataSource = new DataSource();
            spinner = FindViewById<Spinner>(Resource.Id.spinner);
            b1 = FindViewById<Button>(Resource.Id.b1);
            b2 = FindViewById<Button>(Resource.Id.b2);
            et1 = FindViewById<EditText>(Resource.Id.text1);

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
                string ratingText = et1.Text.Trim();
                Book book = books[spinner.SelectedItemPosition];
                if(ratingText.Length == 0 )
                {
                    message = "Please Enter Some Rating";
                }
                else
                {
                    try
                    {
                        int rating = int.Parse(ratingText);
                        if(rating >= 1 && rating <= 10)
                        {
                            Rating record = new Rating();
                            record.BookID = book.BookID.ToString();
                            record.BookName = book.BookName;
                            record.UserName = username;
                            record.Star = rating;
                            if (dataSource.AddBookRating(record))
                            {
                                message = "Book Rating is Saved";
                            }
                            else
                            {
                                message = "Book Rating in not Saved";
                            }
                        }
                        else
                        {
                            message = "Rating must be between 1 to 10";
                        }
                    }
                    catch(Exception ex)
                    {
                        message = "PLease Enter Number in RAting";
                    }
                }
            }
            else
            {
                message = "There is No Book Available For Rating.";
            }
            Toast.MakeText(this, message, ToastLength.Long).Show();
        }

    }
}