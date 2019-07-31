using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Auth;
using Java.Lang;
using static Android.Views.View;

namespace PermissionRequestApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IOnClickListener, IOnCompleteListener, IOnFailureListener
    {
        Button logIn;
        public static FirebaseApp app;
        AutoCompleteTextView userEamil;
        EditText userPass;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            FirebaseApp.InitializeApp(Application.Context);            
            logIn = (Button)FindViewById(Resource.Id.btn_signIn);
            userPass = (EditText)FindViewById(Resource.Id.password);
            userEamil = (AutoCompleteTextView)FindViewById(Resource.Id.email);
            

            logIn.SetOnClickListener(this);
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

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public void OnClick(View v)
        {
            if(v.Id == Resource.Id.btn_signIn)
            {
                FirebaseAuth.Instance.SignInWithEmailAndPassword(userEamil.Text, userPass.Text).AddOnCompleteListener(this).AddOnFailureListener(this);                

            }

        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if (task.IsSuccessful)
            {
                Toast toast = Toast.MakeText(this.ApplicationContext, "Welcom! Your are logged on!", ToastLength.Long);
                toast.Show();
            }
            else
            {

                Toast toast = Toast.MakeText(this.ApplicationContext, "Sorry! Failed to Login", ToastLength.Long);
                toast.Show();
            }
        }

        public void OnFailure(Java.Lang.Exception e)
        {
            
        }
    } 
}

