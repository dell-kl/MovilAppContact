using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FormularioSesion.Models
{

    [Table("Usuario")]
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int usuario_id { set; get; }

        [MaxLength(50)]
        public string usuario_nombre { set; get; }
        
        [MaxLength(50)]
        public string usuario_apellido { set; get; }
        public int usuario_rol { set; get; }

        [Unique]
        [MaxLength(50)]
        public string usuario_username { set; get; }

        [MaxLength(100)]
        public string usuario_password { set; get; }    

    }
}
