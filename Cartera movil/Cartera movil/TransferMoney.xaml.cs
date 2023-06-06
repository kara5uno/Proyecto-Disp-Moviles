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
    public partial class TransferMoney : ContentPage
    {
        private CarterasDeUsuario wallets;
        public TransferMoney(string userName)
        {
            wallets.GetDataOfUser(userName);
            //TODO: mostrar las carteras con el dinero que tienen dentro SEBASTIAN
            InitializeComponent();
        }

        private void Transfer(string name1, string name2, float money)
        {
            wallets.AddMoney(name1, -money);
            wallets.AddMoney(name2, money);
        }
    }
}