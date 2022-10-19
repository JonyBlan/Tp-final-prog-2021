using System;
using TP11.Models;
using System.Data.SqlClient;

namespace TP11.Models
{
    public class Especialidad
    {
        private int _IdEspecialidad;
        private string _Nombre;
        private string _Materia;

        public int IdEspecialidad { 
            get {
                return _IdEspecialidad;
            }
            set {
                _IdEspecialidad = value;
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

        public string Materia { 
            get {
                return _Materia;
            }
            set {
                _Materia = value;
            }
        }

        public Especialidad(){

        }

        public Especialidad(int IdEspecialidad, string Nombre, string Materia){
            _IdEspecialidad = IdEspecialidad;
            _Nombre = Nombre;
            _Materia = Materia;
        }
    }
}