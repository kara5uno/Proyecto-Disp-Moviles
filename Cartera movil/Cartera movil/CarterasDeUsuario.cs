using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Net.Http;
using Cartera_movil.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace Cartera_movil
{
    internal class CarterasDeUsuario
    {
        public List<Cartera> carteras = new List<Cartera>();
        public string user;
        HttpClient client = new HttpClient();
        string URL = "https://carteramovil2023.azurewebsites.net/api/carteras";
        public async void AddMoney(string name, float money)
        {
            foreach (Cartera wallet in carteras)
            {
                if (wallet.Name == name)
                {
                    wallet.Dinero += money;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(wallet), Encoding.UTF8, "application/json");

                    await client.PutAsync(URL, content);

                    break;
                }
            }
            return;
        }
        public async void GetDataOfUser(string userName)
        {
            /*    //PlaceHolder
                var resultado = await client.GetAsync(URL);

                var json = resultado.Content.ReadAsStringAsync().Result;

                carteras = Cartera.FromJson(json);

                carteras.RemoveAll(x => x.Name != userName);
            */

            user = "Prueba";
            carteras = new List<Cartera>();
            carteras.Add(new Cartera());
            carteras.Add(new Cartera());

        }
        public async void createWallet(string name)
        {
            bool repetidos = false;
            foreach(Cartera wallet in carteras)
            {
                if(wallet.Name==name)
                {
                    repetidos = true;
                }
            }
            if (!repetidos)
            {
                Cartera wall= new Cartera();
                
                wall.Name = name;
                
                StringContent content = new StringContent(JsonConvert.SerializeObject(wall), Encoding.UTF8, "application/json");
                
                await client.PostAsync(URL, content);
            }
        }
        public async void deleteWallet(string name)
        {
            foreach (Cartera wallet in carteras)
            {
                if (wallet.Name == name)
                {
                    await client.DeleteAsync(URL + "/" + wallet.Id.ToString());
                    break;
                }
            }
        }
        public float getMoney(string name)
        {
            foreach (Cartera wallet in carteras)
            {
                if (wallet.Name == name)
                {
                    return wallet.Dinero;
                }
            }
            return 0;
        }
    }
}
