using System.Windows.Input;
using Xamarin.Forms;

namespace FormularioSesion.ViewModel.Contactos
{
    public class ContactosViewModel
    {
        /* Comandos registrados  */
        public ICommand VerMenuCommand { set; get; }
        public ICommand EliminarRegistroCommand { set; get; }
        public ICommand ActualizarRegistroCommand { set; get; }

        public ContactosViewModel() {
            VerMenuCommand = new Command(VerMenuEvent);
            EliminarRegistroCommand = new Command<int>(EliminarRegistroEvent);
            ActualizarRegistroCommand = new Command<int>(ActualizarRegistroEvent);
        }

        public void EliminarRegistroEvent(int id = 0)
        {
            //vamos a eliminar uno de nuestros registros o contacto....
        }

        public void VerMenuEvent()
        {
            if (Application.Current.MainPage is FlyoutPage flyoutPage)
            {
                flyoutPage.IsPresented = !flyoutPage.IsPresented;
            }
        }

        public void ActualizarRegistroEvent(int id = 0)
        { 
            //vamos a actualizar una de nuestros registros o contacto...
        }
    }
}
