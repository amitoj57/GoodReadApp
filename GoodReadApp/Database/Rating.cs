using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoodReadApp.Database
{
    public class Rating
    {
        [PrimaryKey, AutoIncrement]
        public int RatingID { get; set; }

        public string UserName { get; set; }

        public string BookID { get; set; }

        public string BookName { get; set; }

        public int Star { get; set; }
    }
}