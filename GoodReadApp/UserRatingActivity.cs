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
    [Activity(Label = "My Book Rating")]
    public class UserRatingActivity : AppCompatActivity
    {
        Button b1;
        ListView list1;
        DataSource dataSource;
        BookRatingAdapter adapter;
        string username;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_user_all_books);
            username = Intent.GetStringExtra("UserName");
            dataSource = new DataSource();

            b1 = FindViewById<Button>(Resource.Id.b1);
            list1 = FindViewById<ListView>(Resource.Id.list1);

            b1.Click += B1_Click; ;

            adapter = new BookRatingAdapter(this, dataSource.GetUserRatings(username));
            list1.Adapter = adapter;

        }

        private void B1_Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
}