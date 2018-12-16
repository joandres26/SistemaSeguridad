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
        

        // GET: Usuario
        public ActionResult Usuario()
        {
            return View();
        }
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