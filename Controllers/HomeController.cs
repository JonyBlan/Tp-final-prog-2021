using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TP11.Models;

namespace TP11.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static bool administrador = false;
        public static List<Curso> CarritoCompras = new List<Curso>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult VerAdministradores()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            List<Curso> cursos = new List<Curso>();
            List<Administrador> administradores = new List<Administrador>();
            administradores = BD.ListarAdministradores();
            especialidades = BD.ListarEspecialidades();
            cursos = BD.ListarCursos(-1);
            ViewBag.especialidades = especialidades;
            ViewBag.cursos = cursos;
            @ViewBag.esAdministrador = administrador;
            @ViewBag.administradores = administradores;
            return View();
        }

        public IActionResult AgregarAdministrador(string nombre, string password){
            List<Especialidad> especialidades = new List<Especialidad>();
            List<Curso> cursos = new List<Curso>();
            especialidades = BD.ListarEspecialidades();
            cursos = BD.ListarCursos(-1);
            @ViewBag.especialidades = especialidades;
            @ViewBag.cursos = cursos;
            @ViewBag.esAdministrador = administrador;
            Administrador nuevoAdmin = new Administrador(nombre, password);
            bool realizado;
            realizado = BD.AgregarAdministrador(nuevoAdmin);
            if(realizado == false){
                @ViewBag.error = "error en BorrarAdministrador, dentro del homeController. realizado no deberia valer false";
                return View("Error");
            }
            else{
                @ViewBag.aviso = "Se ha eliminado el administrador con exito";
                return View("Index");
            }
        }

        public IActionResult BorrarAdministrador(int idAdmin)
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            List<Curso> cursos = new List<Curso>();
            especialidades = BD.ListarEspecialidades();
            cursos = BD.ListarCursos(-1);
            @ViewBag.especialidades = especialidades;
            @ViewBag.cursos = cursos;
            @ViewBag.esAdministrador = administrador;
            bool realizado;
            realizado = BD.EliminarAdministrador(idAdmin);
            if(realizado == false){
                @ViewBag.error = "error en BorrarAdministrador, dentro del homeController. realizado no deberia valer false";
                return View("Error");
            }
            else{
                @ViewBag.aviso = "Se ha eliminado el administrador con exito";
                return View("Index");
            }
        }

        public IActionResult Index()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            List<Curso> cursos = new List<Curso>();
            especialidades = BD.ListarEspecialidades();
            cursos = BD.ListarCursos(-1);
            ViewBag.especialidades = especialidades;
            ViewBag.cursos = cursos;
            @ViewBag.esAdministrador = administrador;
            return View();
        }

        public IActionResult AgregarAlCarrito(Curso unCurso){
            List<Especialidad> especialidades = new List<Especialidad>();
            List<Curso> cursos = new List<Curso>();
            especialidades = BD.ListarEspecialidades();
            cursos = BD.ListarCursos(-1);
            @ViewBag.especialidades = especialidades;
            @ViewBag.cursos = cursos;
            @ViewBag.esAdministrador = administrador;
            foreach(Curso cadaCurso in CarritoCompras){
                if(cadaCurso.IdCurso == unCurso.IdCurso){
                    @ViewBag.aviso = "El curso ya se encontraba en el carrito";
                    return View("Index");
                }
            }
            CarritoCompras.Add(unCurso);
            @ViewBag.aviso = "Se agrego el curso al carrito exitosamente";
            return View("Index");
        }

        public IActionResult SacarDelCarrito(Curso unCurso){
            List<Especialidad> especialidades = new List<Especialidad>();
            List<Curso> cursos = new List<Curso>();
            especialidades = BD.ListarEspecialidades();
            cursos = BD.ListarCursos(-1);
            @ViewBag.especialidades = especialidades;
            @ViewBag.cursos = cursos;
            @ViewBag.esAdministrador = administrador;
            foreach(Curso cadaCurso in CarritoCompras){
                if(cadaCurso.IdCurso == unCurso.IdCurso){
                    @ViewBag.aviso = "Se ha eliminado el curso del carrito exitosamente";
                    CarritoCompras.Remove(unCurso);
                    return View("Index");
                }
            }
            @ViewBag.aviso = "El curso no se encontraba en el carrito";
            return View("Index");
        }

        public IActionResult VaciarCarrito(){
            List<Especialidad> especialidades = new List<Especialidad>();
            List<Curso> cursos = new List<Curso>();
            especialidades = BD.ListarEspecialidades();
            cursos = BD.ListarCursos(-1);
            @ViewBag.especialidades = especialidades;
            @ViewBag.cursos = cursos;
            @ViewBag.esAdministrador = administrador;
            CarritoCompras.Clear();
            @ViewBag.aviso = "Se ha vaciado el carrito de compras con exito";
            return View("Index");
        }

        public IActionResult Pagar(){
            List<Especialidad> especialidades = new List<Especialidad>();
            List<Curso> cursos = new List<Curso>();
            especialidades = BD.ListarEspecialidades();
            cursos = BD.ListarCursos(-1);
            int precio = 0;
            @ViewBag.especialidades = especialidades;
            @ViewBag.cursos = cursos;
            @ViewBag.esAdministrador = administrador;
            foreach(Curso unCurso in CarritoCompras){
                precio = precio + unCurso.Precio;
            }
            @ViewBag.precio = precio;
            return View();
        }

        public IActionResult VerCarrito(){
            List<Especialidad> especialidades = new List<Especialidad>();
            List<Curso> cursos = new List<Curso>();
            especialidades = BD.ListarEspecialidades();
            cursos = BD.ListarCursos(-1);
            int precio = 0;
            @ViewBag.especialidades = especialidades;
            @ViewBag.cursos = cursos;
            @ViewBag.esAdministrador = administrador;
            foreach(Curso unCurso in CarritoCompras){
                precio = precio + unCurso.Precio;
            }
            @ViewBag.precio = precio;
            @ViewBag.carrito = CarritoCompras;
            return View();
        }

        public IActionResult EsAdministrador(string contraseña){
            if(contraseña == "46483420"){
                administrador = true;
                @ViewBag.aviso = "Se ha entrado en un perfil de administrador exitosamente";
            }
            else{
                @ViewBag.aviso = "Contraseña incorrecta";
            }
            @ViewBag.esAdministrador = administrador;
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MostrarCursosxEspecialidad(int idEspecialidad)
        {
            List<Curso> cursosxEspecialidad = new List<Curso>();
            cursosxEspecialidad = BD.ListarCursos(idEspecialidad);
            List<Especialidad> especialidades = new List<Especialidad>();
            especialidades = BD.ListarEspecialidades();
            @ViewBag.especialidades = especialidades;
            @ViewBag.cursos = cursosxEspecialidad;
            @ViewBag.titulo = especialidades[idEspecialidad-1].Nombre;
            @ViewBag.esAdministrador = administrador;
            return View("Index");
        }

        public IActionResult VerCurso(int idCurso)
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            especialidades = BD.ListarEspecialidades();
            @ViewBag.especialidades = especialidades;
            Curso unCurso = null;
            unCurso = BD.ConsultaCurso(idCurso);
            @ViewBag.esAdministrador = administrador;
            @ViewBag.carrito = CarritoCompras;
            bool coinciden = false;
            foreach(Curso algunCurso in CarritoCompras){
                if(algunCurso.IdCurso == unCurso.IdCurso){
                    coinciden = true;
                }
            }
            @ViewBag.coinciden = coinciden;
            if(unCurso == null){
                @ViewBag.error = "error en VerCurso, dentro del homeController. el usuario no deberia ser capaz de ingresar un curso no existente";
                return View("Error");
            }
            else{
                @ViewBag.curso = unCurso;
                return View("DetalleCurso");
            }
        }

        public IActionResult Calificar(int idCurso, bool gusta)
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            especialidades = BD.ListarEspecialidades();
            @ViewBag.especialidades = especialidades;
            Curso unCurso = null;
            unCurso = BD.ConsultaCurso(idCurso);
            @ViewBag.esAdministrador = administrador;
            if(unCurso == null){
                @ViewBag.error = "error en Calificar, dentro del homeController. el usuario no deberia ser capaz de ingresar un curso no existente";
                return View("Error");
            }
            else{
                bool realizado = false;
                realizado = BD.CalificarCurso(idCurso, gusta);
                if(realizado == false){
                    @ViewBag.error = "error en calificar, dentro del homeController. realizado no deberia valer false";
                    return View("Error");
                }
                else{
                    unCurso = BD.ConsultaCurso(idCurso);
                    @ViewBag.curso = unCurso;
                    @ViewBag.aviso = "Se ha efectuado el voto con exito";
                    return View("DetalleCurso");
                }
            }
        }

        public IActionResult AgregarCurso()
        {
            List<Curso> cursos = new List<Curso>();
            cursos = BD.ListarCursos(-1);
            @ViewBag.cursos = cursos;
            @ViewBag.esAdministrador = administrador;
            List<Especialidad> especialidades = new List<Especialidad>();
            especialidades = BD.ListarEspecialidades();
            @ViewBag.especialidades = especialidades;
            @ViewBag.esAdministrador = administrador;
            return View();
        }

        public IActionResult BorrarContacto(int idContacto){
            List<Especialidad> especialidades = new List<Especialidad>();
            List<Curso> cursos = new List<Curso>();
            especialidades = BD.ListarEspecialidades();
            cursos = BD.ListarCursos(-1);
            @ViewBag.especialidades = especialidades;
            @ViewBag.cursos = cursos;
            @ViewBag.esAdministrador = administrador;
            bool realizado = BD.BorrarContacto(idContacto);
            @ViewBag.esAdministrador = administrador;
            if(realizado == true){
                List<Contacto> contactos = new List<Contacto>();
                contactos = BD.ListarContactos();
                @ViewBag.contactos = contactos;
                return View("VerContactos");
            }
            else{
                @ViewBag.error = "ERROR en guardar curso, dentro de homeController, realizado no deberia ser false";
                return View("Error");
            }
        }

        public IActionResult VerContactos(){
            List<Especialidad> especialidades = new List<Especialidad>();
            List<Curso> cursos = new List<Curso>();
            List<Contacto> contactos = new List<Contacto>();
            contactos = BD.ListarContactos();
            especialidades = BD.ListarEspecialidades();
            cursos = BD.ListarCursos(-1);
            @ViewBag.especialidades = especialidades;
            @ViewBag.cursos = cursos;
            @ViewBag.esAdministrador = administrador;
            @ViewBag.contactos = contactos;
            return View();
        }

        public IActionResult Contacto(){
            List<Especialidad> especialidades = new List<Especialidad>();
            List<Curso> cursos = new List<Curso>();
            especialidades = BD.ListarEspecialidades();
            cursos = BD.ListarCursos(-1);
            @ViewBag.especialidades = especialidades;
            @ViewBag.cursos = cursos;
            @ViewBag.esAdministrador = administrador;
            return View();
        }

        [HttpPost]
        public IActionResult GuardarContacto(string Nombre, string Email, string Consulta){
            List<Especialidad> especialidades = new List<Especialidad>();
            List<Curso> cursos = new List<Curso>();
            especialidades = BD.ListarEspecialidades();
            cursos = BD.ListarCursos(-1);
            @ViewBag.especialidades = especialidades;
            @ViewBag.cursos = cursos;
            @ViewBag.esAdministrador = administrador;
            Contacto elContacto = new Contacto(Nombre, Email, Consulta);
            bool realizado = BD.AgregarInfoContacto(elContacto);
            if(realizado == true){
                @ViewBag.cursos = cursos;
                return View("Index");
            }
            else{
                @ViewBag.error = "ERROR en GuardarContacto, dentro de homeController, realizado no deberia ser false";
                return View("Error");
            }
        }

        public IActionResult AgregarReunionZoom(int idCurso, string link){
            List<Especialidad> especialidades = new List<Especialidad>();
            List<Curso> cursos = new List<Curso>();
            especialidades = BD.ListarEspecialidades();
            cursos = BD.ListarCursos(-1);
            @ViewBag.especialidades = especialidades;
            @ViewBag.cursos = cursos;
            @ViewBag.esAdministrador = administrador;
            bool realizado = BD.AgregarReunionZoom(idCurso, link);
            @ViewBag.esAdministrador = administrador;
            if(realizado == true){
                cursos = BD.ListarCursos(-1);
                @ViewBag.cursos = cursos;
                return View("Index");
            }
            else{
                @ViewBag.error = "ERROR en AgregarReunionZoom, dentro de homeController, realizado no deberia ser false";
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult GuardarCurso(string nombre, int idEspecialidad, string descripcion, string imagen, string urlCurso, int meGusta, int noMeGusta, int precio, string ReunionZoom)
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            especialidades = BD.ListarEspecialidades();
            @ViewBag.especialidades = especialidades;
            Curso elCurso = new Curso(nombre, idEspecialidad, descripcion, imagen, urlCurso, meGusta, noMeGusta, precio, ReunionZoom);
            bool realizado = BD.AgregarCurso(elCurso);
            @ViewBag.esAdministrador = administrador;
            if(realizado == true){
                List<Curso> cursos = new List<Curso>();
                cursos = BD.ListarCursos(-1);
                @ViewBag.cursos = cursos;
                return View("Index");
            }
            else{
                @ViewBag.error = "ERROR en guardar curso, dentro de homeController, realizado no deberia ser false";
                return View("Error");
            }
        }

        public IActionResult Verificacion(){
            List<Especialidad> especialidades = new List<Especialidad>();
            List<Curso> cursos = new List<Curso>();
            especialidades = BD.ListarEspecialidades();
            cursos = BD.ListarCursos(-1);
            @ViewBag.especialidades = especialidades;
            @ViewBag.cursos = cursos;
            @ViewBag.esAdministrador = administrador;
            return View();
        }

        public IActionResult CerrarSesion(string respuesta){
            List<Especialidad> especialidades = new List<Especialidad>();
            List<Curso> cursos = new List<Curso>();
            especialidades = BD.ListarEspecialidades();
            cursos = BD.ListarCursos(-1);
            @ViewBag.esAdministrador = administrador;
            @ViewBag.especialidades = especialidades;
            @ViewBag.cursos = cursos;
            if(respuesta == "si"){
                administrador = false;
                @ViewBag.esAdministrador = administrador;
                return View("Index");
            }
            else if(respuesta == "no"){
                return View("Index");
            }
            else{
                @ViewBag.aviso = "ERROR en verificacion(string respuesta), dentro de HomeController, respuesta solo deberia poder valer si o no";
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult Verificacion(string usuario, string password){
            List<Especialidad> especialidades = new List<Especialidad>();
            List<Curso> cursos = new List<Curso>();
            List<Administrador> administradores = new List<Administrador>();
            administradores = BD.ListarAdministradores();
            especialidades = BD.ListarEspecialidades();
            cursos = BD.ListarCursos(-1);
            @ViewBag.especialidades = especialidades;
            @ViewBag.cursos = cursos;
            @ViewBag.esAdministrador = administrador;
            foreach(Administrador unAdministrador in administradores){
                if(unAdministrador.Nombre == usuario){
                    if(unAdministrador.Password == password){
                        administrador = true;
                        @ViewBag.esAdministrador = administrador;
                        @ViewBag.aviso = "Se ha activado el modo administrador";
                        return View("Index");
                    }
                    else{
                        @ViewBag.aviso = "Usuario o contraseña incorrectos";
                        return View();
                    }
                }
            }
            @ViewBag.aviso = "Usuario o contraseña incorrectos";
            return View();
        }

        public IActionResult EliminarCurso(int idCurso){
            List<Especialidad> especialidades = new List<Especialidad>();
            List<Curso> cursos = new List<Curso>();
            especialidades = BD.ListarEspecialidades();
            @ViewBag.especialidades = especialidades;
            @ViewBag.esAdministrador = administrador;
            bool realizado = BD.EliminarCurso(idCurso);
            cursos = BD.ListarCursos(-1);
            @ViewBag.cursos = cursos;
            if(realizado == true){
                @ViewBag.aviso="Se ha eliminado el curso correctamente";
                return View("Index");
            }
            else{
                @ViewBag.aviso = "ERROR en eliminarCurso, dentro de HomeController, realizado no deberia ser false";
                return View("Error");
            }
        }

        public IActionResult BorrarLikes(int idCurso){
            List<Especialidad> especialidades = new List<Especialidad>();
            List<Curso> cursos = new List<Curso>();
            especialidades = BD.ListarEspecialidades();
            cursos = BD.ListarCursos(-1);
            @ViewBag.especialidades = especialidades;
            @ViewBag.cursos = cursos;
            @ViewBag.esAdministrador = administrador;
            bool realizado = BD.BorrarLikes(idCurso);
            if(realizado==true){
                @ViewBag.aviso = "Se han borrado los likes y dislikes exitosamente";
                return View("Index");
            }
            else{
                @ViewBag.aviso = "ERROR en borrarLikes dentro de HomeController, realizado no deberia ser false";
                return View("Error");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

/*
    List<Especialidad> especialidades = new List<Especialidad>();
    List<Curso> cursos = new List<Curso>();
    especialidades = BD.ListarEspecialidades();
    cursos = BD.ListarCursos(-1);
    @ViewBag.especialidades = especialidades;
    @ViewBag.cursos = cursos;
    @ViewBag.esAdministrador = administrador;
*/