using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using App3.Annotations;
using Xamarin.Forms;

namespace App3
{
    class MasterViewModel : INotifyPropertyChanged
    {
        private readonly List<MasterPageItem> _items = new List<MasterPageItem>
        {
            new MasterPageItem("Second Page", MasterPageItemKind.Page, typeof(SecondPage)),
            new MasterPageItem("Third Page", MasterPageItemKind.Page, typeof(ThirdPage)),
            new MasterPageItem("Test Modal", MasterPageItemKind.Modal, typeof(TestModalPage)),
        };

        private readonly INavigation _navigation;
        private readonly Action _closeMaster;

        public MasterViewModel(INavigation navigation, Action closeMaster)
        {
            _navigation = navigation;
            _closeMaster = closeMaster;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public IList<MasterPageItem> Items => _items;

        public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedItem = (MasterPageItem)e.SelectedItem;
            var page = (Page)Activator.CreateInstance(selectedItem.Type);
            switch (selectedItem.Kind)
            {
                case MasterPageItemKind.Modal:
                    _navigation.PushModalAsync(page);
                    break;
                case MasterPageItemKind.Page:
                    _navigation.PushAsync(page);
                    break;
                default:
                    throw new NotSupportedException();
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
