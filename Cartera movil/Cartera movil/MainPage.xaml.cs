using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cartera_movil
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void OnButtonClicked(object sender, EventArgs e)
        {
            if (CheckUserInformation(userName.Text,password.Text))
            {
                App.Current.MainPage = new MainMenu(userName.Text);
            }
            else
            {
                //si estan mal
                await DisplayAlert("","Usuario o contraseña Incorrectos", "Ok");
            }
        }

        private bool CheckUserInformation(string userName, string password)
        {
            //TODO: Regresa true si el usuario y contrasena son correctos ALAN
            return true;
        }

    }
}
