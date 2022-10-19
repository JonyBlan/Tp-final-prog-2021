using System;
using TP11.Models;
using System.Data.SqlClient;

namespace TP11.Models
{
    public class Contacto
    {
        private int _IdContacto;
        private string _Nombre;
        private string _Email;
        private string _Consulta;

        public int IdContacto { 
            get {
                return _IdContacto;
            }
            set {
                _IdContacto = value;
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

        public string Email { 
            get {
                return _Email;
            }
            set {
                _Email = value;
            }
        }

        public string Consulta { 
            get {
                return _Consulta;
            }
            set {
                _Consulta = value;
            }
        }

        public Contacto(){

        }

        public Contacto(int IdContacto, string Nombre, string Email, string Consulta){
            _IdContacto = IdContacto;
            _Nombre = Nombre;
            _Email = Email;
            _Consulta = Consulta;
        }

        public Contacto(string Nombre, string Password, string Consulta){
            _Nombre = Nombre;
            _Email = Password;
            _Consulta = Consulta;
        }
    }
}