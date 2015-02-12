using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using UnitKing.Core;
using Android.Views.InputMethods;

namespace UnitKing.Android
{
    [Activity(Label = "UnitKing.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button add;
        private EditText current;
        private EditText target;
        private EditText carbohydrates;
        private TextView suggested;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.MainActivity);
            
            InitUI();
            AddEventHandlers();
            Calculation.Weight = 195;
        }

        private void AddEventHandlers()
        {
            current.TextChanged += current_TextChanged;
            target.TextChanged += target_TextChanged;
            carbohydrates.TextChanged += carbohydrates_TextChanged;

            current.FocusChange += view_FocusChange;
            target.FocusChange += view_FocusChange;
            carbohydrates.FocusChange += view_FocusChange;
        }

        void view_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            if(!e.HasFocus)
            {
                InputMethodManager manager = (InputMethodManager)GetSystemService(InputMethodService);
                manager.HideSoftInputFromWindow(((View)sender).WindowToken, HideSoftInputFlags.NotAlways);
            }
        }


        void current_TextChanged(object sender, global::Android.Text.TextChangedEventArgs e)
        {
            int num = 0;
            if (int.TryParse(e.Text.ToString(), out num))
            {
                Calculation.Actual = num;
            }

            DisplaySuggestedUnits();
        }

        void target_TextChanged(object sender, global::Android.Text.TextChangedEventArgs e)
        {
            int num = 0;
            if (int.TryParse(e.Text.ToString(), out num))
            {
                Calculation.Target = num;
            }

            DisplaySuggestedUnits();
        }

        void carbohydrates_TextChanged(object sender, global::Android.Text.TextChangedEventArgs e)
        {
            int num = 0;
            if (int.TryParse(e.Text.ToString(), out num))
            {
                Calculation.Carbohydrates = num;
            }

            DisplaySuggestedUnits();
        }

        private void DisplaySuggestedUnits()
        {
            suggested.Text = Calculation.TotalMealtimeDose + " units";
        }

        private void InitUI()
        {
            add = FindViewById<Button>(Resource.Id.saveBtn);
            current = FindViewById<EditText>(Resource.Id.current);
            target = FindViewById<EditText>(Resource.Id.target);
            carbohydrates = FindViewById<EditText>(Resource.Id.carbohydrates);
            suggested = FindViewById<TextView>(Resource.Id.suggested);
        }
    }
}

