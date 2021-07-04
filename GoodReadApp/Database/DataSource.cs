using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GoodReadApp.Database
{
    public class DataSource
    {
        private SQLiteConnection connection;

        public string ErrorMessage { get; set; }

        public DataSource()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            connection = new SQLiteConnection(Path.Combine(path, "good_reads.db"));
            try
            {
                connection.CreateTable<Login>();
                connection.CreateTable<Book>();
                connection.CreateTable<Rating>();
            }
            catch (Exception ex)
            {

            }
        }
        public bool ValidUser(string username, string password)
        {
            List<Login> users = connection.Query<Login>("Select * from Login");
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].UserName.Equals(username) && users[i].Password.Equals(password))
                {
                    return true;
                }

            }
            return false;
        }
        public bool AddNewUser(Login user)
        {
            try
            {
                connection.Insert(user);
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }
        public bool AddNewBook(Book book)
        {
            try
            {
                connection.Insert(book);
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }

        public bool AddBookRating(Rating rating)
        {
            try
            {
                connection.Insert(rating);
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }

        public List<Book> GetAllBooks()
        {
            List<Book> books = connection.Query<Book>("Select * from Book");
            return books;
        }
        public List<Login> GetAllUsers()
        {
            List<Login> users = connection.Query<Login>("Select * from Login");
            return users;
        }

        public List<Rating> GetAllRatings()
        {
            List<Rating> ratings = connection.Query<Rating>("Select * from Rating");
            return ratings;
        }

        public List<Rating> GetUserRatings(string username)
        {
            List<Rating> ratings = new List<Rating>();
            List<Rating> records = GetAllRatings();
            foreach (Rating record in records)
            {
                if (record.UserName.Equals(username))
                {
                    ratings.Add(record);
                }
            }
            return ratings;
        }
        public bool DeleteBook(Book book)
        {
            try
            {
                connection.Delete(book);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteRating(Rating rating)
        {
            try
            {
                connection.Delete(rating);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}