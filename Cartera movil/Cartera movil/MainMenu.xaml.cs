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
            Title = "Mis carteras";

            Button[] buttons;
            foreach(wallet )
                x= new Button
            {
                Text = "Click to Rotate Text!",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            button.Clicked += async (sender, args) => await label.RelRotateTo(360, 1000);

            Content = new StackLayout
            {
                Children =
                {   
                    label,
                    button
                }
            };
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