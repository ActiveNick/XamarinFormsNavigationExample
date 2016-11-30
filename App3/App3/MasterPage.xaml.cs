using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App3
{
    public partial class MasterPage : ContentPage
    {
        private readonly MasterViewModel _viewModel;

        public MasterPage(INavigation navigation, Action closeMaster)
        {
            InitializeComponent();

            _viewModel = new MasterViewModel(navigation, closeMaster);

            BindingContext = _viewModel;
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _viewModel.OnItemSelected(sender, e);
        }
    }
}
