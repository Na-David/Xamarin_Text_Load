using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using System;
using System.IO;



namespace Text_Reader
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView TV;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            TV = FindViewById<TextView>(Resource.Id.textView1);

            Button button = FindViewById<Button>(Resource.Id.load_text);
            button.Click += CLICK;
        }

        void CLICK(object sender, EventArgs e)
        {
            string text;
            using (StreamReader sr = new StreamReader(Assets.Open("This_I_Believe.txt")))
            {
                text = sr.ReadToEnd();
            }
            TV.Text = text;

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}