using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormularioSesion.Models;
using SQLite;

namespace FormularioSesion.Repository
{
    public class ContactoRepository<T> where T : class
    {
        public string Mensaje { set; get; }

        private readonly SQLiteConnection _connection;

        private static ContactoRepository<T> _instance;
        public static ContactoRepository<T> Instance { 
            get
            {
                if (_instance == null)
                    throw new Exception("Debe llamar a nuestro inicializador");

                return _instance;
            }
        }

        public static void Inicializador(string filename)
        {
            if (filename == null)
                throw new Exception("Debes agregar el filename");

            if (_instance != null)
                _instance._connection.Close();

            _instance = new ContactoRepository<T>(filename);
        }

        private ContactoRepository(string conexionString)
        {
            _connection = new SQLiteConnection(conexionString);

            _connection.CreateTable<Contacto>();
        }

        public int AddUser(T us)
        {
            int resultado = 0;

            try
            {
                resultado = _connection.Insert(us);

                this.Mensaje = $"El numero de filas afectas es : {resultado} resultados";
            }
            catch (Exception ex)
            {
                this.Mensaje = "Error, Verifica si ya existe el numero de cel/tel o el correo.";
                //throw new Exception("Error en la insercion del registro");
            }

            return resultado;
        }

        public IEnumerable<Contacto> ListarUser()
        {
            try
            {
                return this._connection.Table<Contacto>();
            }
            catch (Exception ex) {
                this.Mensaje = "Los registros no pudieron ser retornados";
                throw new Exception("Los datos no pudieron ser traidos");
            }

        }

        public Contacto FindUser(int identificador)
        {
            try
            {   
                Contacto registro = this._connection.Table<Contacto>().Where(cont => cont.contacto_id.Equals(identificador)).First();
                return registro;
            }
            catch (Exception ex) {
                this.Mensaje = "No se pudo encontrar el registro";
                throw new Exception("El registro no se pudo ser retornado");
            }
        }


        public int DeleteUser(int identificador)
        {
            int resultado = 0;
            try
            {
                Contacto contacto = FindUser(identificador);
                resultado = this._connection.Delete(contacto);
                this.Mensaje = $"El numero de filas afectas es : {resultado} resultados";
            }
            catch (Exception ex) {
                this.Mensaje = "Numero de filas afectadas : 0 resultados";
                throw new Exception("Error en la eliminacion del registro");
            }

            return resultado;
        }

        public int UpdateUser(T contacto)
        {
            int resultado = 0;

            try
            {
                resultado = this._connection.Update(contacto);
                this.Mensaje = $"El numero de filas afectas es : {resultado} resultados";
            }
            catch (Exception ex) {
                this.Mensaje = "Numero de filas afectadas : 0 resultados";
                throw new Exception("Error en la actualizacion del registro");
            }

            return resultado;
        }

    }
}
