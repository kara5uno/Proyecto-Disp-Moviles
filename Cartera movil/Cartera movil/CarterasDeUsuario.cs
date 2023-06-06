using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Cartera_movil
{
    internal class CarterasDeUsuario
    {
        //Para cosas raras de xamarin
        private static Page page;
        public List<Cartera> carteras;
        public string user;
        public void AddMoney(string name, float money)
        {
            foreach (Cartera wallet in carteras)
            {
                if (wallet.name == name)
                {
                    wallet.dinero += money;
                    break;
                }
            }
            return;
        }
        public void GetDataOfUser(string userName)
        {
            //PlaceHolder
            user = "Prueba";
            carteras = new List<Cartera>();
            carteras.Add(new Cartera("comida",5.0f));
            carteras.Add(new Cartera("escuela", 5.0f));
            carteras.Add(new Cartera("transporte", 5.0f));
            carteras.Add(new Cartera("servicios", 5.0f));
            carteras.Add(new Cartera("monas chinas", 50.0f));
            //TODO Obtener la informacion de la base de datos del userName ALAN
        }
        public void saveDataOfUser()
        {
            //TODO guardar la informacion actual en la base de datos ALAN
        }
        public async void createWallet(string name)
        {
            bool repetidos = false;
            foreach(Cartera wallet in carteras)
            {
                if(wallet.name==name)
                {
                    repetidos = true;
                }
            }
            if (!repetidos)
            {
                carteras.Add(new Cartera(name, 0.0f));
            }
            else
            {
                await page.DisplayAlert("Nombre invalido", "Ya existe una cartera con ese nombre", "Ok");
            }
        }
        public void deleteWallet(string name)
        {
            //TODO eliminar la cartera con nombre 'name' ALAN
            //Siempre se daran nombres validos
        }
    }
}
