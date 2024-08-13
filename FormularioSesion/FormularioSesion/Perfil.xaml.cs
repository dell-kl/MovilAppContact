using FormularioSesion.Models;
using System;
using System.Linq;
using Xamarin.Forms;
using FormularioSesion.Repository;

namespace FormularioSesion
{
	public partial class Perfil : ContentPage
    {
		private string Mensaje;
		public Perfil()
		{
			InitializeComponent();

        }

		public void MostrarBarraLateral(object obj, EventArgs e)
		{
			
			if ( Application.Current.MainPage is FlyoutPage flyoutPage)
			{
				
				flyoutPage.IsPresented = !flyoutPage.IsPresented;
			}
        }

        public void registrarContacto(object obj, EventArgs e)
		{
			try
			{
				Contacto contacto = new Contacto() { 
					contacto_nombre = nombreContacto.Text.Trim(),
					contacto_apellido = apellidoContacto.Text.Trim(),
					contacto_email = correoContacto.Text.Trim(),
					contacto_numeroCelular = celularContacto.Text.Trim(),
					contacto_descripcion = descripcionContacto.Text.Trim()
				};

				if ( 
					contacto.contacto_nombre.Count() > 0 &&
					contacto.contacto_apellido.Count() > 0 &&
					contacto.contacto_email.Count() > 0 &&
					contacto.contacto_numeroCelular.Count() > 0 &&
					contacto.contacto_descripcion.Count() > 0
				)
				{
					int resultado = ContactoRepository<Contacto>.Instance.AddUser(contacto);
					Mensaje = ContactoRepository<Contacto>.Instance.Mensaje;

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
			catch(NullReferenceException ex)
			{
                Mensaje = "Debes completar todos los campos";
                ingresarMensaje();
            }
		}

		public void ingresarMensaje(bool estado = false)
		{
            if (EspacioMensajesError.Children.Count != 0)
            {
				EspacioMensajesError.Children.Clear();
            }

			var elemento = new Label()
			{
				Text = Mensaje,
				TextColor = Color.Red,
				FontAttributes = FontAttributes.Bold,
				FontSize = 15,
				WidthRequest = 322,
				HorizontalTextAlignment = TextAlignment.Center
			};

            if ( !estado )
			{
				EspacioMensajesError.Children.Add(elemento);
				EspacioMensajesError.BackgroundColor = Color.FromHex("FFCFCF");
			}
			else
			{
				elemento.TextColor = Color.FromHex("5EF205");
                EspacioMensajesError.Children.Add(elemento);
                EspacioMensajesError.BackgroundColor = Color.FromHex("D6F5B4");
            }

            EspacioMensajesError.Padding = 5;
        }


		public void limpiarFormulario()
		{
			nombreContacto.Text = null;
			apellidoContacto.Text = null;
			correoContacto.Text = null;
			celularContacto.Text = null;
			descripcionContacto.Text = null;
        }
    }
}