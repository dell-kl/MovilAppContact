using FormularioSesion.Dto;
using FormularioSesion.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormularioSesion.Repository
{
    public class UsuarioRepository
    {
        public string Mensaje { set; get; }

        private readonly SQLiteConnection _connection;

        private static UsuarioRepository _instance;
        public static UsuarioRepository Instance
        {
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

            _instance = new UsuarioRepository(filename);
        }

        private UsuarioRepository(string conexionString)
        {
            _connection = new SQLiteConnection(conexionString);
            _connection.CreateTable<Usuario>();
        }

        public int FindByLogin(SesionDto sesion)
        {
            int resultado = 0;

            try
            {
                var registro = _connection.Table<Usuario>().Where(usua => usua.usuario_username.Equals(sesion.Username) && usua.usuario_password.Equals(sesion.Password)).ToList();

                if (registro.Count > 0)
                {
                    resultado = 1;
                }
                else
                {
                    this.Mensaje = $"No se pudo encontrar el perfil.";
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"No se pudo traer el registro.... Error : {ex.Message}");
            }

            return resultado;
        }

        public int AddUsuario(Usuario usuario)
        {
            int resultado = 0;

            try
            {
                resultado = _connection.Insert(usuario);

                this.Mensaje = $"El numero de filas afectas es : {resultado} resultados";
            }
            catch (Exception ex)
            {
                this.Mensaje = "Numero de filas afectadas : 0 resultados";
            }

            return resultado;
        }
    }
}
