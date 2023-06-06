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
    public partial class WalletPage : ContentPage
    {
        private CarterasDeUsuario wallets = new CarterasDeUsuario();
        string wallet;
        public WalletPage(string userName, string walletName)
        {
            wallets.GetDataOfUser(userName);
            wallet = walletName;
            InitializeComponent();
            ReloadWallets();
            carteraActual.Text= wallet;
        }
        private void ReloadWallets()
        {
            var myList = wallets.carteras; //your list here
            carteras.Children.Clear(); //just in case so you can call this code several times np..
            foreach (var item in myList)
            {
                var btn = new Button()
                {
                    Text = item.name + "  " + item.dinero.ToString(), //Whatever prop you wonna put as title;
                    StyleId = item.name
                };
                btn.Clicked += ClickWallet;
                carteras.Children.Add(btn);
            }
        }
        private void ClickWallet(object sender, EventArgs e)
        {
            var myBtn = sender as Button;
            var name = myBtn.StyleId;
            return;
        }
        private void Return(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainMenu(wallets.user);
        }

        private void EnterMoney(object sender, EventArgs e)
        {
            wallets.AddMoney(wallet,(float)Convert.ToDouble(agregar.Text));
            ReloadWallets();
        }
    }
}