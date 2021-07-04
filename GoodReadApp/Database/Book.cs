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
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int BookID { get; set; }

        public string BookName { get; set; }

        public string Description { get; set; }

        public string Authors { get; set; }

        public int Pages { get; set; }
    }
}