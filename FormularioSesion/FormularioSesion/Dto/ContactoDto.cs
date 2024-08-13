using System;

namespace FormularioSesion.Dto
{
    public class ContactoDto
    {
        public int id;
        private string nombre;
        private string apellido;
        private string email;
        private string numerocel;
        private string descrip;

        public int contacto_id
        {
            get;set;
        }
        
        public string contacto_nombre
        { 
            get {  return nombre; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    nombre = "sin_data";
                }
                else 
                    nombre = value;
            }
        }

        public string contacto_apellido
        {
            get { return apellido; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    apellido = "sin_data";
                }
                else
                    apellido = value;
            }
        }

        public string contacto_email
        {
            get { return email; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    email = "sin_data";
                }
                else 
                    email = value;
            }
        }

        public string contacto_numeroCelular
        {
            get { return numerocel; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    numerocel = "sin_data";
                }
                else
                    numerocel = value;
            }
        }

        public string contacto_descripcion
        {
            get { return descrip; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    descrip = "sin_data";
                }
                else
                    descrip = value;
            }
        }

        public ContactoDto(int id, string nombre, string apellido, string email, string numerocel, string descrip)
        {
            this.contacto_id = id;
            this.contacto_nombre = nombre;
            this.contacto_apellido = apellido;
            this.contacto_email = email;
            this.contacto_numeroCelular = numerocel;
            this.contacto_descripcion = descrip;
        }

        public ContactoDto() {  }
    }
}
