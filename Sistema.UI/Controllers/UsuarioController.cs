using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema.Model;

namespace Sistema.UI.Controllers
{
    public class UsuarioController : Controller
    {
        private SistemaSeguridadEntities bd = new SistemaSeguridadEntities();
      

        // GET: Usuario
        public ActionResult Usuario()
        {
            Session["Rol"] = "0";
            return View();
        }

       

        [HttpPost]
        public ActionResult Usuario(Usuario elModelo)
        {
            Usuario us = bd.Usuario.FirstOrDefault(d => d.idUsuario == elModelo.idUsuario & d.Contrasenia == elModelo.Contrasenia);
            if (us != null)
            {
                switch (us.IdRol) {
                    case 1:
                        Session["Rol"] = "1";
                        break;
                    case 2:
                        Session["Rol"] = "2";
                        break;
                    case 3:
                        Session["Rol"] = "3";
                        break;
                    default:
                        Session["Rol"] = "0";
                        break;
                    
                }
                    
                return RedirectToAction("Index", "Home");
            }
            else
            {
                RedirectToAction("Error", "Home");
            }


            return View();
        }

        public ActionResult Logout()
        {
            Session["Rol"] = "0";
            return RedirectToAction("Usuario", "Usuario");
        }//Fin del método Logout.

        public ActionResult Error()
        {
            ViewBag.Error = "No se encontro el usuario con estos datos";

            return View();
        }



        //Trate comparar
        /*
        [HttpPost]
        public ActionResult Usuario(Usuario elModelo)
        {
            
            var idUsuarioVerificado = Verificar(elModelo);
            elModelo.idUsuario = idUsuarioVerificado;
            ViewBag.idUsuario = idUsuarioVerificado;
            
           

            return View(elModelo);
        }

        SistemaSeguridadEntities contexto = new SistemaSeguridadEntities();
        private int Verificar(Usuario elModelo)
        {
            
            try
            {
                var usuario = from u in contexto.Usuario
                              where u.idUsuario == (int)elModelo.idUsuario && u.Contrasenia == elModelo.Contrasenia
                              select u.idUsuario;

                return usuario.FirstOrDefault();


            }
            catch (Exception)
            {
                return 0;
                throw;
            }
    
        }

    */

        //de maynor

        //[HttpPost]
        //public ActionResult Index(string idUsuario, string contrasenia) {
        //    Usuario u = new Usuario();

        //    return View();
        //}
        //[HttpGet]
        //public IEnumerable<Usuario> GetUsuarios() {
        //    Usuario u = new Usuario();

        //    return u;
        //} 
    }
}