using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cartera_movil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoneyDeposit : ContentPage
    {
        public MoneyDeposit(string userName)
        {
            //TODO: mostrar las carteras con el dinero que tienen dentro
            InitializeComponent();
        }
        private void Deposit(string name, float money)
        {
            //TODO Agregar 'money' a cartera 'name' ALAN
        }
    }
}