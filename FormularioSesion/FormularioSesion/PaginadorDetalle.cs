using Xamarin.Forms;
using FormularioSesion.Views;
using FormularioSesion.Views.Perfiles;
using FormularioSesion.Views.NavBar;

namespace FormularioSesion
{
    public class PaginadorDetalle : FlyoutPage
    {
        public PaginadorDetalle(bool estado = false)
        {
            //esto bloquea para que el usuario no tenga que ver la barra lateral arrastrando con el dedo
            //al aplicacion obliga a usar un boton hamburguesa para poder ver dicho menu lateral.
            NavigationPage.SetHasNavigationBar(this, false); 
            Flyout = new NavBarView();

            if (estado)
            {
                Detail = new NavigationPage(new GestorContactView());
            }
            else
            {
                Detail = new NavigationPage(new SesionView());
            }

            this.IsGestureEnabled = false;
        }

    }
}
