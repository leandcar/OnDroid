﻿using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Fragged.Fragments;
using Fragment = Android.Support.V4.App.Fragment;

namespace Fragged.Activities
{
    [Activity(Label = "Fragged", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button button1;
        private Button button2;
        private Button button3;
        readonly FragmentOne fragment1 = new FragmentOne();
        readonly FragmentTwo fragment2 = new FragmentTwo();
        readonly FragmentThree fragment3 = new FragmentThree();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.main_activity);

            var toolBar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolBar);

            button1 = FindViewById<Button>(Resource.Id.button1);
            button1.Click += (sender, args) => {ReplaceFragment(fragment1, Resource.Animation.slide_out_left);  };

            button2 = FindViewById<Button>(Resource.Id.button2);
            button2.Click += (sender, args) => { ReplaceFragment(fragment2, Resource.Animation.slide_out_down); };

            button3 = FindViewById<Button>(Resource.Id.button3);
            button3.Click += (sender, args) => { ReplaceFragment(fragment3, Resource.Animation.slide_out_right); };
        }

        private void ReplaceFragment(Fragment fragment, int selectedAnimation)
        {
            var trans = SupportFragmentManager.BeginTransaction();

            trans.SetCustomAnimations(Resource.Animation.slide_in, selectedAnimation, Resource.Animation.slide_in, selectedAnimation);

            trans.Replace(Resource.Id.contentFrame, fragment);
            trans.Commit();
        }
    }
}