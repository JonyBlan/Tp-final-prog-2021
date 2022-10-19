using System;
using TP11.Models;
using System.Data.SqlClient;

namespace TP11.Models
{
    public class Curso
    {
        private int _IdCurso;
        private string _Nombre;
        private int _IdEspecialidad;
        private string _Descripcion;
        private string _Imagen;
        private string _UrlCurso;
        private int _MeGusta;
        private int _NoMeGusta;
        private int _Precio;
        private string _ReunionZoom;

        public int IdCurso { 
            get {
                return _IdCurso;
            }
            set {
                _IdCurso = value;
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

        public int IdEspecialidad { 
            get {
                return _IdEspecialidad;
            }
            set {
                _IdEspecialidad = value;
            }
        }

        public string Descripcion { 
            get {
                return _Descripcion;
            }
            set {
                _Descripcion = value;
            }
        }

        public string Imagen { 
            get {
                return _Imagen;
            }
            set {
                _Imagen = value;
            }
        }

        public string UrlCurso { 
            get {
                return _UrlCurso;
            }
            set {
                _UrlCurso = value;
            }
        }

        public int MeGusta { 
            get {
                return _MeGusta;
            }
            set {
                _MeGusta = value;
            }
        }

        public int NoMeGusta { 
            get {
                return _NoMeGusta;
            }
            set {
                _NoMeGusta = value;
            }
        }

        public int Precio{
            get{
                return _Precio;
            }
            set{
                _Precio = value;
            }
        }

        public string ReunionZoom{
            get{
                return _ReunionZoom;
            }
            set{
                _ReunionZoom = value;
            }
        }

        public Curso(){

        }

        public Curso(int IdCurso, string Nombre, int IdEspecialidad, string Descripcion, string Imagen, string UrlCurso, int MeGusta, int NoMeGusta, int Precio, string ReunionZoom)
        {
            _IdCurso = IdCurso;
            _Nombre = Nombre;
            _IdEspecialidad = IdEspecialidad;
            _Descripcion = Descripcion;
            _Imagen = Imagen;
            _UrlCurso = UrlCurso;
            _MeGusta = MeGusta;
            _NoMeGusta = NoMeGusta;
            _Precio = Precio;
            _ReunionZoom = ReunionZoom;
        }

        public Curso(string Nombre, int IdEspecialidad, string Descripcion, string Imagen, string UrlCurso, int MeGusta, int NoMeGusta, int Precio, string ReunionZoom)
        {
            _Nombre = Nombre;
            _IdEspecialidad = IdEspecialidad;
            _Descripcion = Descripcion;
            _Imagen = Imagen;
            _UrlCurso = UrlCurso;
            _MeGusta = MeGusta;
            _NoMeGusta = NoMeGusta;
            _Precio = Precio;
            _ReunionZoom = ReunionZoom;
        }

        public Curso(int IdCurso, string Nombre, int IdEspecialidad, string Descripcion, string Imagen, string UrlCurso, int MeGusta, int NoMeGusta, int Precio)
        {
            _IdCurso = IdCurso;
            _Nombre = Nombre;
            _IdEspecialidad = IdEspecialidad;
            _Descripcion = Descripcion;
            _Imagen = Imagen;
            _UrlCurso = UrlCurso;
            _MeGusta = MeGusta;
            _NoMeGusta = NoMeGusta;
            _Precio = Precio;
        }

        public Curso(string Nombre, int IdEspecialidad, string Descripcion, string Imagen, string UrlCurso, int MeGusta, int NoMeGusta, int Precio)
        {
            _Nombre = Nombre;
            _IdEspecialidad = IdEspecialidad;
            _Descripcion = Descripcion;
            _Imagen = Imagen;
            _UrlCurso = UrlCurso;
            _MeGusta = MeGusta;
            _NoMeGusta = NoMeGusta;
            _Precio = Precio;
        }
    }
}