using FormularioSesion.Models;
using FormularioSesion.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormularioSesion
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ActualizarContactos : ContentPage
	{
		public ActualizarContactos (Contacto contacto)
		{
			BindingContext = contacto;
			InitializeComponent ();
		}

		public void Regresar(object sender, EventArgs e) => Navigation.PopAsync();

		public void actualizarContacto(object  sender, EventArgs e)
		{
			
            Contacto contacto = new Contacto()
            {
				contacto_id = int.Parse(botonActualizar.ClassId),
                contacto_nombre = nombreContacto.Text,
                contacto_apellido = apellidoContacto.Text,
                contacto_email = correoContacto.Text,
                contacto_numeroCelular = celularContacto.Text,
                contacto_descripcion = descripcionContacto.Text,
            };

			//int resultado = ContactoRepository.Instance.UpdateUser(contacto);
			//string mensaje = ContactoRepository.Instance.Mensaje;

			Navigation.PopAsync();
		}


    }
}