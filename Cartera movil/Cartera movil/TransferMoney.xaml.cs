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
        private Cartera[] carteras;
        private string user;
        public TransferMoney(string userName)
        {
            //TODO: recuperar carteras del usuario y ponerlo en carteras Alan
            //TODO: mostrar las carteras con el dinero que tienen dentro
            InitializeComponent();
        }

        private void Transfer(string name1, string name2, float money)
        {
            //TODO transferir de 'name1' a 'name2' la cantidad 'money' ALAN
        }
    }
}