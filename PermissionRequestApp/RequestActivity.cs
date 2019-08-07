using System;
using System.IO;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using static Android.Views.View;

namespace PermissionRequestApp
{
    [Activity(Label = "RequestActivity", Theme = "@style/AppTheme.NoActionBar")]
    public class RequestActivity : AppCompatActivity, IOnClickListener
    {
        Button addRequest;
        EditText reqDate, reqReason;
        Spinner reqnumHours;
        string _fileName = "RequestFile.txt";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_request);

            if (!File.Exists(_fileName))
                _fileName = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "RequestFile.txt");
            
            addRequest = (Button)FindViewById(Resource.Id.btn_add_request);

            reqDate = (EditText)FindViewById(Resource.Id.reqDate);
            reqReason = (EditText)FindViewById(Resource.Id.reqReason);
            reqnumHours = (Spinner)FindViewById(Resource.Id.reqnumHours);

            addRequest.SetOnClickListener(this);
            // Create your application here
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btn_add_request)
            {
                string reqDateval = reqDate.Text;
                string reqReasonval = reqReason.Text;
                int reqnumHoursVal = Int32.Parse(reqnumHours.SelectedItem.ToString());

                string input = reqDateval + " " + reqReasonval + " " + reqnumHoursVal.ToString() + "\n";
                File.AppendAllText(_fileName, input); //write information 
                var useractivity = new Intent(this.ApplicationContext, typeof(UserActivity));
                StartActivity(useractivity); // show add request activity
            }
        }
    }
}