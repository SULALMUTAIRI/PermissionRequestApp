using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using static Android.Views.View;

namespace PermissionRequestApp
{
    [Activity(Label = "UserActivity", Theme = "@style/AppTheme.NoActionBar")]
    class UserActivity : AppCompatActivity, IOnClickListener
    {
        Button addRequest, showRequests;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.acivity_user);

            addRequest = (Button)FindViewById(Resource.Id.btn_add_request);
            addRequest.SetOnClickListener(this);
            showRequests = (Button)FindViewById(Resource.Id.btn_show_requests);
            showRequests.SetOnClickListener(this); 
          
        }

        public void Dispose()
        {
        }

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btn_add_request)
            {
                var addRequest = new Intent(this.ApplicationContext, typeof(RequestActivity));
                StartActivity(addRequest); // show add request activity
            }
            if (v.Id == Resource.Id.btn_show_requests)
            {
                var showRequets = new Intent(this.ApplicationContext, typeof(ListActivity));
                StartActivity(showRequets); // show add request activity
            }
        }
    }
}