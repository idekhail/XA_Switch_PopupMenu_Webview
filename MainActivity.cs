using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Content;

namespace popUpMenu_1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_main);
            Button button1 = FindViewById<Button>(Resource.Id.button1);

            //button1.Click += delegate
            //{
            //    PopupMenu
            //    menu = new PopupMenu(this, button1);
            //    menu.Inflate(Resource.Menu.popMenu);
            //    menu.Show();
            //};

            button1.Click += (s, arg) =>
            {
                PopupMenu menu = new PopupMenu(this, button1);
                menu.Inflate(Resource.Menu.popMenu);

                menu.MenuItemClick += (s1, arg1) =>
                {
                    Toast.MakeText(this, arg1.Item.TitleFormatted + "  selected"  , ToastLength.Short).Show();
                };

                menu.DismissEvent += (s2, arg2) =>
                {
                  //  Console.WriteLine("menu dismissed");
                    Toast.MakeText(this, "menu dismissed", ToastLength.Long).Show();
                };
                menu.Show();
            };

            Switch s = FindViewById<Switch>(Resource.Id.do_switch);

            s.CheckedChange += delegate (object sender, CompoundButton.CheckedChangeEventArgs e) {

                var toast = Toast.MakeText(this, "Your answer is " + (e.IsChecked ? "correct" : "incorrect"),                                    ToastLength.Short);
                toast.Show();

               // Toast.MakeText(this, "Your answer is " + (e.IsChecked ? "correct" : "incorrect"), ToastLength.Short).Show();

                //if (e.IsChecked)
                //{
                //    Toast.MakeText(this, "correct", ToastLength.Short).Show();
                //}
                //else
                //{
                //    Toast.MakeText(this, "incorrect", ToastLength.Short).Show();
                //}
            };



            var web = FindViewById<EditText>(Resource.Id.web);
            var display = FindViewById<Button>(Resource.Id.display);

            display.Click += delegate
            {
                Intent i = new Intent(this, typeof(WebViewActivity));
                i.PutExtra("web", web.Text);
                StartActivity(i);

            };
        }
    }
}