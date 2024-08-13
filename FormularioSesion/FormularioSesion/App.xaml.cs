using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FormularioSesion.Models;
using FormularioSesion.Repository;


namespace FormularioSesion
{
    public partial class App : Application
    {
        public App(string filename)
        {
            InitializeComponent();

            ContactoRepository<Contacto>.Inicializador(filename);
            UsuarioRepository.Inicializador(filename);
  
            MainPage =  new PaginadorDetalle();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
