using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sistema.Model;
using System.Linq;
using System.Web;

namespace Sistema.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LoginTest()
        {
            var result = "";
            string[] op = new string[] { "pass", "pass", "pass", "fail" };

            Usuario[] users = new Usuario[4];
            for (int i = 0; i < 4; i++) {
                users[i] = new Usuario();
                switch (i) {
                    case 0:
                        users[0].Nombre = "Adm";
                        users[0].Apellido1 = "Adm";
                        users[0].Apellido2 = "Adm";
                        users[0].IdRol = 1;
                        users[0].idUsuario = 1;
                        users[0].Contrasenia = "Adm";
                        break;
                    case 1:
                        users[1].Nombre = "Custodia";
                        users[1].Apellido1 = "Custodia";
                        users[1].Apellido2 = "Custodia";
                        users[1].IdRol = 2;
                        users[1].idUsuario = 2;
                        users[1].Contrasenia = "Custodia";
                        break;
                    case 2:
                        users[2].Nombre = "Invitado";
                        users[2].Apellido1 = "Invitado";
                        users[2].Apellido2 = "Invitado";
                        users[2].IdRol = 3;
                        users[2].idUsuario = 3;
                        users[2].Contrasenia = "Invitado";
                        break;
                    default:
                        users[i].Nombre = "No";
                        users[i].Apellido1 = "No";
                        users[i].Apellido2 = "No";
                        users[i].IdRol = i;
                        users[i].idUsuario = i;
                        users[i].Contrasenia = "No";
                        break;
                }
                if (users[i].Nombre.Equals("Adm") && users[i].Contrasenia.Equals("Adm"))
                {
                    result = "pass";
                }
                else if (users[i].Nombre.Equals("Custodia") && users[i].Contrasenia.Equals("Custodia"))
                {
                    result = "pass";
                }
                else if (users[i].Nombre.Equals("Invitado") && users[i].Contrasenia.Equals("Invitado"))
                {
                    result = "pass";
                }
                else {
                    result = "fail";
                }
                Assert.AreEqual(result, op[i]);
            }

        }//LoginTest


    }
}
