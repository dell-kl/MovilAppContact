using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormularioSesion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaContactos : ContentPage
    {
        public ListaContactos()
        {
            InitializeComponent();
        }

        public void MostrarBarraLateral(object obj, EventArgs e)
        {
            if (Application.Current.MainPage is FlyoutPage flyoutPage)
            {

                flyoutPage.IsPresented = !flyoutPage.IsPresented;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //IEnumerable<Contacto> registros = ContactoRepository.Instance.ListarUser();
            //ListadoContactos.ItemsSource = registros;
        }

        public void EliminarRegistro(object sender, EventArgs arg)
        {
            /*var boton = (ImageButton) sender;
            int identifiador = int.Parse(boton.ClassId);

            ContactoRepository.Instance.DeleteUser(identifiador);
            string Mensaje = ContactoRepository.Instance.Mensaje;

            Navigation.PushAsync(new ListaContactos());*/
        }

        public void Registro(object sender, EventArgs arg)
        {
           /* var boton = (ImageButton)sender;
            int identifiador = int.Parse(boton.ClassId);

            Contacto registro = ContactoRepository.Instance.FindUser(identifiador);

            Navigation.PushAsync(new ActualizarContactos(registro));*/
        }

    }
}