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
    [Activity(Label = "All Books")]
    public class AllBooksActivity : AppCompatActivity
    {
        Button b1;
        ListView list1;
        DataSource dataSource;
        AllBooksAdapter adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_all_books);
            dataSource = new DataSource();

            b1 = FindViewById<Button>(Resource.Id.b1);
            list1 = FindViewById<ListView>(Resource.Id.list1);

            b1.Click += B1_Click; ;

            adapter = new AllBooksAdapter(this,dataSource.GetAllBooks());
            list1.Adapter = adapter;

        }

        private void B1_Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
}