using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content.Res;
using Android.OS;
using Android.Views;
using Android.Widget;
using Java.Lang;
using NavSample;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.Dependency(typeof(NavSample.Droid.ChangeStatusBar))]
namespace NavSample.Droid
{
	public class ChangeStatusBar: NavSample.IChangeStatusBars
    {

		
		

		public static void setColoredStatusBar(Activity activity,int color)
		{
			Window window = activity.Window;

			// clear FLAG_TRANSLUCENT_STATUS flag:
			window.ClearFlags(WindowManagerFlags.TranslucentStatus);

			// add FLAG_DRAWS_SYSTEM_BAR_BACKGROUNDS flag to the window
			window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);


			// finally change the color
			if(color==0)
                window.SetStatusBarColor(activity.Resources.GetColor(Resource.Color.primary_material_dark));
			else
                window.SetStatusBarColor(activity.Resources.GetColor(Resource.Color.primary_dark_material_light));
		}


		public static void setTransparent(Activity activity, int imageRes)
		{
			if (Build.VERSION.SdkInt < Build.VERSION_CODES.Kitkat)
			{
				return;
			}
			// set flags
			if (Build.VERSION.SdkInt >= Build.VERSION_CODES.Lollipop)
			{
				activity.Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
				activity.Window.ClearFlags(WindowManagerFlags.TranslucentStatus);
				activity.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);

			}
			else {
				activity.Window.AddFlags(WindowManagerFlags.TranslucentStatus);
			}

			

			ViewGroup contentView = (ViewGroup)activity.FindViewById(Android.Resource.Id.Content);
			if (contentView.ChildCount > 1)
			{
				contentView.RemoveViewAt(1);
			}

			// get status bar height
			int res = activity.Resources.GetIdentifier("status_bar_height", "dimen", "android");
			int height = 0;
			if (res != 0)
				height = activity.Resources.GetDimensionPixelSize(res);


			// create new imageview and set resource id
			ImageView image = new ImageView(activity);
			LinearLayout.LayoutParams params1 = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, height);
			params1.Width = LinearLayout.LayoutParams.MatchParent;
			image.LayoutParameters = params1;
			image.SetImageResource(imageRes);

			image.SetScaleType(ImageView.ScaleType.FitXy);

			// add image view to content view
			contentView.AddView(image);
			contentView.SetFitsSystemWindows(true);

		}
		bool doubleBackToExitPressedOnce = false;

		

		public void StatusBarfitWindpws(bool status)
		{
			throw new NotImplementedException();
		}

        public void CloseApplication()
        {
            NavSample.Droid.MainActivity.activity.Finish();
        }

        void IChangeStatusBars.StatusBarColor(int color)
        {
            throw new NotImplementedException();
        }

        void IChangeStatusBars.StatusBarImage(int statusImage)
        {
			if (Build.VERSION.SdkInt >= Build.VERSION_CODES.Lollipop)
			{
                SetTransparent(NavSample.Droid.MainActivity.activity, Resource.Drawable.joblisting_statusbar);
			}
        }

		public static void SetTransparent(Activity activity, int imageRes)
		{
			if (Build.VERSION.SdkInt < Build.VERSION_CODES.Kitkat)
			{
				return;
			}
			// set flags
			if (Build.VERSION.SdkInt >= Build.VERSION_CODES.Lollipop)
			{
				activity.Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
				activity.Window.ClearFlags(WindowManagerFlags.TranslucentStatus);
				activity.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);

			}
			else
			{
				activity.Window.AddFlags(WindowManagerFlags.TranslucentStatus);
			}



			ViewGroup contentView = (ViewGroup)activity.FindViewById(Android.Resource.Id.Content);
			//if (contentView.ChildCount > 1)
			//{
			//	contentView.RemoveViewAt(1);
			//}

			// get status bar height
			int res = activity.Resources.GetIdentifier("status_bar_height", "dimen", "android");
			int height = 0;
			if (res != 0)
				height = activity.Resources.GetDimensionPixelSize(res);


			// create new imageview and set resource id
			ImageView image = new ImageView(activity);
			LinearLayout.LayoutParams params1 = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, height);
			params1.Width = LinearLayout.LayoutParams.MatchParent;
			image.LayoutParameters = params1;
			image.SetImageResource(imageRes);

			image.SetScaleType(ImageView.ScaleType.FitXy);

			// add image view to content view
			contentView.AddView(image);
			contentView.SetFitsSystemWindows(true);

		}
    }
}
