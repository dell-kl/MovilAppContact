using FormularioSesion.Dto;
using FormularioSesion.Models;
using FormularioSesion.Repository;
using Xamarin.Forms;

namespace FormularioSesion.ViewModel
{
    public class SesionViewModel 
    {
        public Command CommandVerificarLogin { get; set; }
        public SesionDto usuarioLogin { get; set; }
        public SesionViewModel() {
            CommandVerificarLogin = new Command(VerificarLoginEvento);
            usuarioLogin = new SesionDto();
        }    

        public void VerificarLoginEvento()
        {
            //Implementamos esta funcionalidad en caso de que no tengamos algun perfil correspondiente. . 
            /*UsuarioRepository.Instance.AddUsuario(new Usuario()
            {
                usuario_id = 0,
                usuario_nombre = "juan",
                usuario_apellido = "carlos",
                usuario_rol = 1,
                usuario_username = "admin",
                usuario_password = "admin"
            });*/

            if (usuarioLogin.Username != null && usuarioLogin.Password != null)
            {
                int resultado = UsuarioRepository.Instance.FindByLogin(usuarioLogin);

                if (resultado != 0)
                    App.Current.MainPage = new PaginadorDetalle(true);
                else
                  App.Current.MainPage.DisplayAlert("Sesion", "Usuario o Contraseña incorrecta", "Continuar");
            }
            else
                App.Current.MainPage.DisplayAlert("Error", "Debes completar todos los campos.", "OK");
        }
    }
}
