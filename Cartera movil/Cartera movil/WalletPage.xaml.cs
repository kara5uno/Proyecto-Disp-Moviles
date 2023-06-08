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
                var grd = new Grid
                {
                    RowDefinitions =
                    {
                        new RowDefinition()
                    },
                    ColumnDefinitions =
                    {
                        new ColumnDefinition(),
                        new ColumnDefinition(),
                        new ColumnDefinition(),
                        new ColumnDefinition(),
                        new ColumnDefinition(),
                        new ColumnDefinition(),
                        new ColumnDefinition(),
                    },
                    BackgroundColor = Xamarin.Forms.Color.FromRgb(100, 104, 110)
                };
                Button btn = new Button
                {
                    StyleId = item.User,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    BackgroundColor = Color.FromRgba(0, 0, 0, 0),
                };
                btn.Clicked += ClickWallet;
                grd.Children.Add(new Label
                {
                    Text = item.User,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                }, 1, 4, 0, 1); ;
                grd.Children.Add(new Label
                {
                    Text = "$" + item.Dinero.ToString(),
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                }, 5, 6, 0, 1);
                grd.Children.Add(btn, 0, 7, 0, 1);
                carteras.Children.Add(grd);
            }
            money.Text = "$" + wallets.getMoney(wallet).ToString();
        }

        private async void ClickWallet(object sender, EventArgs e)
        {
            var myBtn = sender as Button;
            var name = myBtn.StyleId;
            string result = await DisplayPromptAsync("Introduce la cantidad a transferir", "");
            wallets.AddMoney(name, (float)Convert.ToDouble(result));
            wallets.AddMoney(wallet, -(float)Convert.ToDouble(result));
            ReloadWallets();
            return;
        }
        private async void DestroyWallet(object sender, EventArgs e)
        {
            var result = await DisplayAlert("De verdad quieres eliminar esta cartera?", "No podras deshacer esta accion", "Si", "No");
            if (result)
            {
                wallets.deleteWallet(wallet);
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
        }

        private void ExitMoney(object sender, EventArgs e)
        {
            wallets.AddMoney(wallet, (float)Convert.ToDouble(retirar.Text));
            ReloadWallets();
        }
    }
}