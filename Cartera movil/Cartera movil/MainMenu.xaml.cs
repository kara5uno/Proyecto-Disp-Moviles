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
        private Cartera[] carteras;
        private string user;
        public MainMenu(string userName)
        {
            //TODO: recuperar carteras del usuario y ponerlo en carteras Alan
            
            //TODO: mostrar las carteras con el dinero que tienen dentro Sebastian
            InitializeComponent();
            user= userName;
        }

        private void CreateWallet(string name)
        {
            //TODO Crear cartera con nombre 'name' ALAN
        }

        private void DeleteWallet(string name) 
        {
            //TODO Destruir cartera con nombre 'name' ALAN
        }

        private void MoneyDeposit(object sender, EventArgs e)
        {
            App.Current.MainPage = new MoneyDeposit(user);
        }

        private void TransferMoney(object sender, EventArgs e)
        {
            App.Current.MainPage = new TransferMoney(user);
        }

        private void WithdrawMoney(object sender, EventArgs e)
        {
            App.Current.MainPage = new WithdrawMoney(user);
        }
    }
}