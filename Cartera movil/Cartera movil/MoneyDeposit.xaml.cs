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
        private CarterasDeUsuario wallets;
        public MoneyDeposit(string userName)
        {
            wallets.GetDataOfUser(userName);
            //TODO: mostrar las carteras con el dinero que tienen dentro Sebastian
            InitializeComponent();
        }
        private void Deposit(string name, float money)
        {
            wallets.AddMoney(name, money);
        }
    }
}