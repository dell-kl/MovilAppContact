using FormularioSesion.Dto;
using FormularioSesion.ViewModel.NavBar;
using System.Linq;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormularioSesion.Views.NavBar
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavBarView : ContentPage
    {
        public NavBarView()
        {
            InitializeComponent();
            VistaColeccion.SelectionChanged += OnSelectionChanged;
        }

        public void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object[] contenido = new object[] { sender, e };
            NavBarViewModel viewModel = new NavBarViewModel();
            viewModel.CollectionViewCommand.Execute(contenido);
        }
    }
}