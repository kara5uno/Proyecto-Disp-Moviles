﻿using System;
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
        private CarterasDeUsuario wallets= new CarterasDeUsuario();
        public MainMenu(string userName)
        {
            wallets.GetDataOfUser(userName);
            InitializeComponent();
            ReloadWallets();
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
            App.Current.MainPage = new WalletPage(wallets.user,name);
            return;
        }
        private async void CreateWallet(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Crear nueva cartera", "Introduce nombre de la nueva cartera");
            if (!(result is null))
            {
                if(! wallets.createWallet(result))
                {
                    await DisplayAlert("Cartera repetida", result, "ok");
                }
                wallets.saveDataOfUser();
                ReloadWallets();
            }
        }
    }
}