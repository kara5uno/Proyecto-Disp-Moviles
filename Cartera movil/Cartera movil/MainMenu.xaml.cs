﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cartera_movil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu : ContentPage
    {
        public MainMenu(string userName)
        {
            InitializeComponent();
            //TODO: mostrar las carteras con el dinero que tienen dentro
        }

        private void MoneyDeposit(object sender, EventArgs e)
        {
            App.Current.MainPage = new MoneyDeposit();
        }
    }
}