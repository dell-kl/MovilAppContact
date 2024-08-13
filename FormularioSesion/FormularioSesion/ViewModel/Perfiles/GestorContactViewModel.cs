using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using FormularioSesion.Models;
using FormularioSesion.Repository;
using FormularioSesion.Dto;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FormularioSesion.ViewModel.Perfiles
{
    public class GestorContactViewModel : INotifyPropertyChanged
    {
        public ICommand VerMenuCommand { get; set; }
        public ICommand RegistrarContactoCommand { get; set; }
        public ContactoDto contactoViewModel { get; set; }


        /* estas dos propiedades de aqui abajo nos serviran para mostrar u ocultar los
         * mensajes informativos para el cliente.*/
        private bool _controladorVistaMensaje { get; set; } = false;
        private String _mensaje { get; set; } = "sinMensaje";
        private String _banderaColor { get; set; } = "red";
        private String _banderaBackColor { get; set; } = "";


        public GestorContactViewModel() {
            contactoViewModel = new ContactoDto();
            VerMenuCommand = new Command(VerMenuEvent);
            RegistrarContactoCommand = new Command(RegistrarContactoEvent);
        }

        public void VerMenuEvent()
        {
            if (Application.Current.MainPage is FlyoutPage flyoutPage)
            {

                flyoutPage.IsPresented = !flyoutPage.IsPresented;
            }
        }

        public void RegistrarContactoEvent()
        {
            try
            {
                //lo volvemos a introducir dentro de una instancia del Dto,
                //ya que tenemos algunas validaciones en la parte de los setter....
                ContactoDto registro = new ContactoDto(
                    0,
                    contactoViewModel.contacto_nombre,
                    contactoViewModel.contacto_apellido,
                    contactoViewModel.contacto_email,
                    contactoViewModel.contacto_numeroCelular,
                    contactoViewModel.contacto_descripcion
                );


                if (
                    registro.contacto_nombre != "sin_data" &&
                    registro.contacto_apellido != "sin_data" &&
                    registro.contacto_email != "sin_data" &&
                    registro.contacto_numeroCelular != "sin_data" &&
                    registro.contacto_descripcion != "sin_data"
                )
                {
                    int resultado = ContactoRepository<ContactoDto>.Instance.AddUser(contactoViewModel);
                    Mensaje = ContactoRepository<ContactoDto>.Instance.Mensaje;

                    if (resultado == 0)
                    {
                        ingresarMensaje();
                    }
                    else
                    {
                        Mensaje = "Contacto guardado correctamente";
                        ingresarMensaje(true);
                        limpiarFormulario();
                    }
                }
                else
                {
                    Mensaje = "Debes completar todos los campos";
                    ingresarMensaje();
                }


            }
            catch (NullReferenceException ex)
            {
                Mensaje = "Debes completar todos los campos";
                ingresarMensaje();
            }
        }

        /*
         * Con esta metodos nos sacamos la informacion de nuestro webServices , 
         * el cual dicha funcionalidad esta implementadaa en otra parte de 
         * nuestro codigo. 
         */
        public void ObtenerInformacionPaises()
        {

        }


        /* Este codigo esta relacionado con un label de la interfaz, 
         * el cual vamos a insertar un mensaje para que el usuario 
         * lo pueda observar 
         */
        public void ingresarMensaje(bool estado = false)
        {
            ControlarVistaMensaje = true;
            
            if ( !estado ) // no se registro el contacto
            {
                this.BanderaColor = "red";
                this.BanderaBackColor = "#FFCFCF";
            }
            else
            {
                this.BanderaColor = "green";
                this.BanderaBackColor = "#D6F5B4";
            }

        }

        public void limpiarFormulario()
        {
            contactoViewModel = new ContactoDto();
        }


        /*
         * Dentro de Este ViewModel nosotros estamos haciendo actualizaciones en
         * la propiedad "ControlarVistaMensaje" y "BanderaColor", etc., por esa razon
         * usaremos esta codigo siguiente para hacer una actualizacion al instante 
         * en la UI.
         */
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }




        /* estas dos propiedades de aqui abajo nos serviran para mostrar u ocultar los
         * mensajes informativos para el cliente.*/
        public bool ControlarVistaMensaje { 
            get
            {
                return _controladorVistaMensaje;
            }
            set
            {
                _controladorVistaMensaje = value;
                OnPropertyChanged();
            } 
        }
        public String Mensaje {
            get 
            {
                return _mensaje;
            } 
            set
            {
                _mensaje = value;
                OnPropertyChanged();
            }
        } 
        public String BanderaColor {
            get
            {
                return _banderaColor;
            }
            set
            {
                _banderaColor = value;
                OnPropertyChanged();
            }
        } 

        public String BanderaBackColor
        {
            get
            {
                return _banderaBackColor;
            }
            set
            { 
                _banderaBackColor = value;
                OnPropertyChanged();
            }
        }

    }
}
