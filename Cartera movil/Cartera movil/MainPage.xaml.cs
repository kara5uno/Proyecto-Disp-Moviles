using Cartera_movil.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cartera_movil
{
    public partial class MainPage : ContentPage
    {
        List<Usuario> usuarios = new List<Usuario>();   
        public MainPage()
        {
            InitializeComponent();
            CargarUsuarios();
        }

        private async void CargarUsuarios()
        {
            HttpClient client = new HttpClient();

            string URL = "https://carteramovil2023.azurewebsites.net/api/usuarios";
            
            var resultado = await client.GetAsync(URL);
            
            var json = resultado.Content.ReadAsStringAsync().Result;

            usuarios = Usuario.FromJson(json);
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
        //    foreach (var item in usuarios)
        //       if (item.Username.ToString() == userName && item.Password.ToString() == password)
        //            return true;
            return true;
        }

    }
}
