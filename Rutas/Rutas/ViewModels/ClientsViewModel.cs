namespace Rutas.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Common.Models;
    using GalaSoft.MvvmLight.Command;
    using Services;
    using Xamarin.Forms;

    public class ClientsViewModel : BaseViewModel
    {
        private ApiService apiService;

        private ObservableCollection<Client> clients;

        private bool refrescar;

        public ObservableCollection<Client> Clients
        {
            get { return this.clients; }
            set { this.SetValue(ref this.clients, value); }
        }

        public bool Refrescar
        {
            get { return this.refrescar; }
            set { this.SetValue(ref this.refrescar, value); }
        }

        public ClientsViewModel()
        {
            this.apiService = new ApiService();
            //var baseApi = (string)Application.Current.Resources["UrlAPI"];
            this.LoadClients();
        }

        private async void LoadClients()
        {
            this.Refrescar = true;

            var conexion = await this.apiService.CheckConnection();
            if (!conexion.IsSuccess)
            {
                this.Refrescar = false;
                await Application.Current.MainPage.DisplayAlert("Error", conexion.Message, "Aceptar");
                return;
            }

            var baseApi = Application.Current.Resources["UrlAPI"].ToString();
            var response = await this.apiService.GetList<Client>(
                baseApi,
                "/api",
                "/Clients");
            if (!response.IsSuccess)
            {
                this.Refrescar = false;
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }

            var lista = (List<Client>)response.Result;
            this.Clients = new ObservableCollection<Client>(lista);
            this.Refrescar = false;
        }

        public ICommand ComandoRefrescar
        {
            get
            {
                return new RelayCommand(LoadClients);
            }
        }
    }
}
