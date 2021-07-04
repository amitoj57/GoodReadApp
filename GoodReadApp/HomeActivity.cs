using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoodReadApp
{
    [Activity(Label = "User Home")]
    public class HomeActivity : AppCompatActivity
    {
        Button b1, b2, b3, b4;
        string username;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_home);

            username = Intent.GetStringExtra("UserName");

            b1 = FindViewById<Button>(Resource.Id.b1);
            b2 = FindViewById<Button>(Resource.Id.b2);
            b3 = FindViewById<Button>(Resource.Id.b3);
            b4 = FindViewById<Button>(Resource.Id.b4);

            b1.Click += B1_Click;
            b2.Click += B2_Click;
            b3.Click += B3_Click;
            b4.Click += B4_Click;
        }

        private void B4_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
            Finish();
        }

        private void B3_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(UserRatingActivity));
            intent.PutExtra("UserName", username);
            StartActivity(intent);
        }

        private void B2_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(AddBookRatingActivity));
            intent.PutExtra("UserName", username);
            StartActivity(intent);
        }

        private void B1_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(UserAllBooksActivity));
            intent.PutExtra("UserName", username);
            StartActivity(intent);
        }
    }
}