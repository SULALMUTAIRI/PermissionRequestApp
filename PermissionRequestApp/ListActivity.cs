using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using static Android.Support.V7.Widget.RecyclerView;

namespace PermissionRequestApp
{
    [Activity(Label = "ListActivity", Theme = "@style/AppTheme.NoActionBar")]
    public class ListActivity : AppCompatActivity
    {
        ListView listView;
        TextView textView;
        String[] listItem;
        Button backToMain;
        string _fileName = "RequestFile.txt";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_list);

            listView = (ListView) FindViewById(Resource.Id.reqlist);

            // get list from file 
            if (!File.Exists(_fileName))
            {
                _fileName = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "RequestFile.txt");
                string str = File.ReadAllText(_fileName);// read the information
                listItem = str.Split(separator: '\n');
                ArrayAdapter<String> Adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, listItem);
                listView.Adapter = Adapter;
                //Adapter.NotifyAll();
                int c = listItem.Length;
            }

            // Create your application here
        }
    }
}