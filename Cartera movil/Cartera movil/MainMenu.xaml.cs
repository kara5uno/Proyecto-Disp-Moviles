using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cartera_movil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu : ContentPage
    {
        private CarterasDeUsuario wallets;
        public MainMenu(string userName)
        {
            wallets.GetDataOfUser(userName);
            //TODO: mostrar las carteras con el dinero que tienen dentro Sebastian
            InitializeComponent();
        }
        private void CreateWallet(string name)
        {
            wallets.createWallet(name);
        }

        private void DeleteWallet(string name) 
        {
            wallets.deleteWallet(name);
        }

        private void MoneyDeposit(object sender, EventArgs e)
        {
            App.Current.MainPage = new MoneyDeposit(wallets.user);
        }

        private void TransferMoney(object sender, EventArgs e)
        {
            App.Current.MainPage = new TransferMoney(wallets.user);
        }

        private void WithdrawMoney(object sender, EventArgs e)
        {
            App.Current.MainPage = new WithdrawMoney(wallets.user);
        }
    }
}