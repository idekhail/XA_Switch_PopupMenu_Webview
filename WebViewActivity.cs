using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Webkit;

namespace popUpMenu_1
{
    [Activity(Label = "WebViewActivity")]
    public class WebViewActivity : Activity
    {
        WebView web_view;
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_webview);

            string web = Intent.GetStringExtra("web");

            web_view = FindViewById<WebView>(Resource.Id.webview);
            web_view.Settings.JavaScriptEnabled = true;
            web_view.SetWebViewClient(new HelloWebViewClient());
            web_view.LoadUrl(web);
        }
        public class HelloWebViewClient : WebViewClient
        {
            // For API level 24 and later
            public override bool ShouldOverrideUrlLoading(WebView view, IWebResourceRequest request)
            {
                view.LoadUrl(request.Url.ToString());
                return false;
            }
        }

        //public class HelloWebViewClient : WebViewClient
        //{
        //    public override bool ShouldOverrideUrlLoading(WebView view, string url)
        //    {
        //        view.LoadUrl(url);
        //        return false;
        //    }
        //}

    }
}