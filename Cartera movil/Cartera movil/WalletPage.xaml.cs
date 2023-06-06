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
            carteraActual.Text = wallet;
        }
        private void ReloadWallets()
        {
            var myList = wallets.carteras; //your list here
            carteras.Children.Clear(); //just in case so you can call this code several times np..
            foreach (var item in myList)
            {
                if(item.name==wallet)
                {
                    continue;
                }
                var btn = new Button()
                {
                    Text = item.name + "  " + item.dinero.ToString(), //Whatever prop you wonna put as title;
                    StyleId = item.name
                };
                btn.Clicked += ClickWallet;
                carteras.Children.Add(btn);
            }
        }
        private async void ClickWallet(object sender, EventArgs e)
        {
            var myBtn = sender as Button;
            var name = myBtn.StyleId;
            string result = await DisplayPromptAsync("Introduce la cantidad a transferir", "");
            wallets.AddMoney(name, (float)Convert.ToDouble(result));
            wallets.AddMoney(wallet, -(float)Convert.ToDouble(result));
            wallets.saveDataOfUser();
            ReloadWallets();
            return;
        }
        private async void DestroyWallet(object sender, EventArgs e)
        {
            var result = await DisplayAlert("De verdad quieres eliminar esta cartera?", "No podras deshacer esta accion", "Si", "No");
            if (result)
            {
                wallets.deleteWallet(wallet);
                wallets.saveDataOfUser();
                Return(sender,e);
            }
        }
        private void Return(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainMenu(wallets.user);
        }

        private void EnterMoney(object sender, EventArgs e)
        {
            wallets.AddMoney(wallet,(float)Convert.ToDouble(agregar.Text));
            ReloadWallets();
            wallets.saveDataOfUser();
        }

        private void ExitMoney(object sender, EventArgs e)
        {
            wallets.AddMoney(wallet, (float)Convert.ToDouble(retirar.Text));
            ReloadWallets();
            wallets.saveDataOfUser();
        }
    }
}