using SQLite;

namespace FormularioSesion.Models
{
    [Table("Contacto")]
    public class Contacto
    {
        [PrimaryKey, AutoIncrement]
        public int contacto_id { get; set; }

        [MaxLength(100)]
        public string contacto_nombre {
            set;get;
        }

        [MaxLength(100)]
        public string contacto_apellido {
            set;get;
        }

        [MaxLength(100), Unique]
        public string contacto_email {
            set;get;
        }

        [MaxLength(15), Unique]
        public string contacto_numeroCelular {
            set;get;
        }

        [MaxLength(100)]
        public string contacto_descripcion {
            set;get;
        }

    }
}
