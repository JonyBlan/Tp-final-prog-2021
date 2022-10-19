using System;
using System.Data.SqlClient;
using Dapper;
using TP11.Models;
using System.Linq;
using System.Collections.Generic;
using System.Data;

namespace TP11.Models
{
    public static class BD
    {
        private static string _connectionString = @"Server=A-PHZ2-CIDI-003; DataBase=BDWebCursos; Trusted_Connection=True;";
        private static List<Curso> ListadoCursos = new List<Curso>();
        private static List<Curso> ListadoCursosxEspecialidad = new List<Curso>();
        private static List<Curso> CarritoCompras = new List<Curso>();
        private static List<Especialidad> ListadoEspecialidades = new List<Especialidad>();
        private static List<Administrador> ListadoAdministradores = new List<Administrador>();
        private static List<Contacto> ListadoContactos = new List<Contacto>();

        public static Curso ConsultaCurso(int Id){
            Curso unCurso = null;
            using(SqlConnection db = new SqlConnection(_connectionString)){
                string sql = "SELECT * FROM Cursos WHERE IdCurso = @pId"; // CAMBIAR "DNI"
                unCurso = db.QueryFirstOrDefault<Curso>(sql, new{pId = Id});
            }
            return unCurso;
        }

        public static bool BorrarLikes(int idCurso) {
            int cambios = 0;
            string sql = "UPDATE Cursos SET MeGusta = 0, NoMeGusta = 0 WHERE IdCurso = @pIdCurso";
            using (SqlConnection db = new SqlConnection (_connectionString)) {
                cambios = db.Execute(sql, new { @pIdCurso = idCurso});
            }
            if(cambios > 0){
                return true;
            }
            else{
                return false;
            }
        }

        public static bool EliminarCurso(int id){
            int realizado;
            using(SqlConnection db = new SqlConnection(_connectionString)){
                string sql = "DELETE FROM Cursos WHERE IdCurso = @pId";
                realizado = db.Execute(sql, new{pId = id});
            }
            if(realizado == 1){
                return true;
            }
            else{
                return false;
            }
        }

        public static bool AgregarAdministrador(Administrador nuevoAdmin){
            int realizado;
            using(SqlConnection db = new SqlConnection(_connectionString)){
                string sql = "INSERT INTO Administradores(Nombre, Password) VALUES (@pNombre, @pPassword)";
                realizado = db.Execute(sql, new{@pNombre = nuevoAdmin.Nombre, @pPassword = nuevoAdmin.Password});
            }
            if(realizado == 1){
                return true;
            }
            else{
                return false;
            }
        }

        public static bool EliminarAdministrador(int id){
            int realizado;
            using(SqlConnection db = new SqlConnection(_connectionString)){
                string sql = "DELETE FROM Administradores WHERE IdAdministrador = @pId";
                realizado = db.Execute(sql, new{pId = id});
            }
            if(realizado == 1){
                return true;
            }
            else{
                return false;
            }
        }

        public static List<Administrador> ListarAdministradores(){
            string sql = "SELECT * FROM Administradores";
            using (SqlConnection db = new SqlConnection (_connectionString)) {
                ListadoAdministradores = db.Query<Administrador>(sql).ToList();
            }
            return ListadoAdministradores;
        }

        public static Especialidad ConsultaEspecialidad(int id){
            Especialidad unaEspecialidad = null;
            using(SqlConnection db = new SqlConnection(_connectionString)){
                string sql = "SELECT * FROM Especialidades WHERE IdEspecialidad = @pid";
                unaEspecialidad = db.QueryFirstOrDefault<Especialidad>(sql, new{@pid = id});
            }
            return unaEspecialidad;
        }

        public static List<Curso> ListarCursos(int Id){
            string sql = "SELECT * FROM Cursos";
            using (SqlConnection db = new SqlConnection (_connectionString)) {
                ListadoCursos = db.Query<Curso>(sql).ToList();
            }
            if(Id == -1){
                return ListadoCursos;
            }
            else{
                ListadoCursosxEspecialidad.Clear();
                for(int i = 0; i < ListadoCursos.Count(); i++){
                    if(ListadoCursos[i].IdEspecialidad == Id){
                        ListadoCursosxEspecialidad.Add(ListadoCursos[i]);
                    }
                }
                return ListadoCursosxEspecialidad;

                /*
                string sql = "SELECT * FROM Cursos WHERE IdEspecialidad = @pId";
                using (SqlConnection db = new SqlConnection (_connectionString)) {
                    ListadoCursosxEspecialidad = db.Query<Curso>(sql, new { pId = Id }).ToList();
                }            
                return ListadoCursosxEspecialidad;
                */
            }
        }

        public static List<Especialidad> ListarEspecialidades() {
            string sql = "SELECT * FROM Especialidades";
                using (SqlConnection db = new SqlConnection (_connectionString)) {
                ListadoEspecialidades = db.Query<Especialidad>(sql).ToList();
            }
            return ListadoEspecialidades;
        }

        public static bool AgregarCurso(Curso UnCurso) {
            int cambios = 0;
            string sql = "INSERT INTO Cursos(Nombre, IdEspecialidad, Descripcion, Imagen, UrlCurso, MeGusta, NoMeGusta) VALUES (@pNombre, @pIdEspecialidad, @pDescripcion, @pImagen, @pUrlCurso, @pMeGusta, @pNoMeGusta)";
            using (SqlConnection db = new SqlConnection (_connectionString)) {
                cambios = db.Execute(sql, new { @pNombre = UnCurso.Nombre, @pIdEspecialidad = UnCurso.IdEspecialidad, @pDescripcion = UnCurso.Descripcion, @pImagen = UnCurso.Imagen, @pUrlCurso = UnCurso.UrlCurso, @pMeGusta = UnCurso.MeGusta, @pNoMeGusta = UnCurso.NoMeGusta});
            }
            if(cambios > 0){
                return true;
            }
            else{
                return false;
            }
        }

        public static bool BorrarContacto(int idContacto){
            int cambios = 0;
            string sql = "DELETE FROM Contacto WHERE IdContacto = @pIdContacto";
            using (SqlConnection db = new SqlConnection (_connectionString)) {
                cambios = db.Execute(sql, new {@pIdContacto = idContacto});
            }
            if(cambios > 0){
                return true;
            }
            else{
                return false;
            }
        }

        public static List<Contacto> ListarContactos(){
            string sql = "SELECT * FROM Contacto";
                using (SqlConnection db = new SqlConnection (_connectionString)) {
                ListadoContactos = db.Query<Contacto>(sql).ToList();
            }
            return ListadoContactos;
        }

        public static bool AgregarInfoContacto(Contacto UnContacto) {
            int cambios = 0;
            string sql = "INSERT INTO Contacto(Nombre, Email, Consulta) VALUES (@pNombre, @pEmail, @pConsulta)";
            using (SqlConnection db = new SqlConnection (_connectionString)) {
                cambios = db.Execute(sql, new {@pNombre = UnContacto.Nombre, @pEmail = UnContacto.Email, @pConsulta = UnContacto.Consulta});
            }
            if(cambios > 0){
                return true;
            }
            else{
                return false;
            }
        }

        public static bool AgregarReunionZoom(int idCurso, string link){
            int cambios = 0;
            string sql = "UPDATE Cursos SET ReunionZoom = @pLink WHERE idCurso = @pIdCurso";
            using (SqlConnection db = new SqlConnection (_connectionString)) {
                cambios = db.Execute(sql, new {@pLink = link, @pIdCurso = idCurso});
            }
            if(cambios > 0){
                return true;
            }
            else{
                return false;
            }
        }

        public static bool CalificarCurso(int IdCurso, bool MeGusta) {
            int cambios = 0;
            if(MeGusta){
                string sql = "UPDATE Cursos SET MeGusta = MeGusta + 1 WHERE IdCurso = @pIdCurso";
                using (SqlConnection db = new SqlConnection (_connectionString)) {
                    cambios = db.Execute(sql, new {@pIdCurso = IdCurso});
                }
            }
            else{
                string sql = "UPDATE Cursos SET NoMeGusta = NoMeGusta + 1 WHERE IdCurso = @pIdCurso";
                using (SqlConnection db = new SqlConnection (_connectionString)) {
                    cambios = db.Execute(sql, new {@pIdCurso = IdCurso});
                }
            }
            if(cambios > 0){
                return true;
            }
            else{
                return false;
            }
        }
    }
}