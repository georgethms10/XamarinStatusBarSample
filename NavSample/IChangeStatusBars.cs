using System;
namespace NavSample
{
	public interface IChangeStatusBars
	{
		void StatusBarColor(int color);
		void StatusBarImage(int statusImage);
		void StatusBarfitWindpws(bool status);
		void CloseApplication();
	}
}
