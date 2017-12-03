using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMExemplo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalculaPage : ContentPage
    {
        public CalculaPage()
        {
            InitializeComponent();
            BindingContext = new ViewModel.CalculaViewModel();
        }
    }
}