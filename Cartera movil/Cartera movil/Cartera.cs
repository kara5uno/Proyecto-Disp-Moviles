using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Cartera_movil
{
    internal class Cartera
    {
        public string name;
        public float dinero;
        public Cartera(string userName, float money)
        {
            name = userName;
            dinero = money;
        }
    }
}
