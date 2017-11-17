using Xamarin.Forms;

namespace NavSample
{
    public partial class NavSamplePage : ContentPage
    {
        public NavSamplePage()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DependencyService.Get<IChangeStatusBars>().StatusBarImage(1);
        }
    }
}
