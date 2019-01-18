namespace Rutas.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class MainViewModel
    {
        public ClientsViewModel Clients { get; set; }

        public MainViewModel()
        {
            this.Clients = new ClientsViewModel();
        }
    }
}
