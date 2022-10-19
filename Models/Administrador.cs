using System;
using TP11.Models;
using System.Data.SqlClient;

namespace TP11.Models
{
    public class Administrador
    {
        private int _IdAdministrador;
        private string _Nombre;
        private string _Password;

        public int IdAdministrador { 
            get {
                return _IdAdministrador;
            }
            set {
                _IdAdministrador = value;
            }
        }

        public string Nombre { 
            get {
                return _Nombre;
            }
            set {
                _Nombre = value;
            }
        }

        public string Password { 
            get {
                return _Password;
            }
            set {
                _Password = value;
            }
        }

        public Administrador(){

        }

        public Administrador(int IdAdministrador, string Nombre, string Password){
            _IdAdministrador = IdAdministrador;
            _Nombre = Nombre;
            _Password = Password;
        }

        public Administrador(string Nombre, string Password){
            _Nombre = Nombre;
            _Password = Password;
        }
    }
}