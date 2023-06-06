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
    public partial class WithdrawMoney : ContentPage
    {
        public WithdrawMoney(string userName)
        {
            //TODO: mostrar las carteras con el dinero que tienen dentro
            InitializeComponent();
        }

        private void Withdraw(string name, float money)
        {
            //TODO ELiminat 'money' de cartera 'name' ALAN
        }
    }
}