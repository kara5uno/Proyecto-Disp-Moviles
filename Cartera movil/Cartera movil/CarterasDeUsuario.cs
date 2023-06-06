using System;
using System.Collections.Generic;
using System.Text;

namespace Cartera_movil
{
    internal class CarterasDeUsuario
    {
        private Cartera[] carteras;
        public string user;
        public void AddMoney(string name, float money)
        {
            //TODO agregar 'money'(posiblemente negativo) a la cartera con nombre 'name' ALAN
        }
        public void GetDataOfUser(string userName)
        {
            //TODO Obtener la informacion de la base de datos del userName ALAN
        }
        public void saveDataOfUser()
        {
            //TODO guardar la informacion actual en la base de datos ALAN
        }
        public void createWallet(string name)
        {
            //TODO crear una cartera con nombre 'name' ALAN
            //No aceptar repetidos
        }
        public void deleteWallet(string name)
        {
            //TODO eliminar la cartera con nombre 'name' ALAN
            //Siempre se daran nombres validos
        }
    }
}
