using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App3
{
    public partial class TestModalPage : ContentPage
    {
        public TestModalPage()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            this.Navigation.PopModalAsync();
        }
    }
}
