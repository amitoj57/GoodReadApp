using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using GoodReadApp.Database;
using Android.Content;

namespace GoodReadApp
{
    [Activity(Label = "Login Screen")]
    public class MainActivity : AppCompatActivity
    {
        Button b1;
        EditText et1, et2;
        TextView tv1;
        DataSource dataSource;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            dataSource = new DataSource();
            et1 = FindViewById<EditText>(Resource.Id.text1);
            et2 = FindViewById<EditText>(Resource.Id.text2);

            b1 = FindViewById<Button>(Resource.Id.b1);
            tv1 = FindViewById<TextView>(Resource.Id.text3);
            b1.Click += B1_Click;
            tv1.Click += Tv1_Click;
        }

        private void Tv1_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(RegisterActivity));
            Finish();
        }

        private void B1_Click(object sender, System.EventArgs e)
        {
            string username = et1.Text.Trim();
            string password = et2.Text;
            if (username.Length == 0 || password.Length == 0)
            {
                Toast.MakeText(this, "Please Fill All Boxes", ToastLength.Long).Show();
            }
            else
            {
                if( username.Equals("good") && password.Equals("good@1234"))
                {
                    Intent intent = new Intent(this, typeof(AdminHomeActivity));
                    StartActivity(intent);
                    Finish();
                }
                else if (dataSource.ValidUser(username, password))
                {
                    Intent intent = new Intent(this, typeof(HomeActivity));
                    intent.PutExtra("UserName", username);
                    StartActivity(intent);
                    Finish();
                }
                else
                {
                    Toast.MakeText(this, "Invalid User Name and Password", ToastLength.Long).Show();
                }
            }

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}