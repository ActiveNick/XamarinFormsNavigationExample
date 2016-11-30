using System.Threading.Tasks;
using Xamarin.Forms;

namespace App3
{
    public partial class SplashPage : ContentPage
    {
        public SplashPage(App app)
        {
            InitializeComponent();

            CheckLogin(app);
        }

        private async void CheckLogin(App app)
        {
            await Task.Delay(1000);
            var navigationPage = new NavigationPage(new MainPage());
            var masterDetailPage = new MasterDetailPage();
            masterDetailPage.Master = new MasterPage(
                navigationPage.Navigation,
                () => masterDetailPage.IsPresented = false);
            masterDetailPage.Detail = navigationPage;

            app.MainPage = masterDetailPage;
        }
    }
}
