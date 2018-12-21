using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sistema.Model;

namespace Sistema.Test
{
    [TestClass]
    public class UnitTest1
    {

        //Login
        [TestMethod]
        public void LoginTest()
        {
            var result = "";
            string[] op = new string[] { "pass", "pass", "pass", "fail" };

            Usuario[] users = new Usuario[4];
            for (int i = 0; i < 4; i++)
            {
                users[i] = new Usuario();
                switch (i)
                {
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
                else
                {
                    result = "fail";
                }
                Assert.AreEqual(result, op[i]);
            }

        }//LoginTest

        //Creates
        [TestMethod]
        public void CreateArticuloTest()
        {
            Articulo a = new Articulo();
            var result = "";
            if (a.IdArticulo == 1)
            {
                result = "pass";
            }
            else
            {
                result = "fail";
            }
            Assert.AreEqual(result, "fail"); // prueba donde no se ha creado articulo

            a.IdArticulo = 1;
            a.IdCategoria = 1;
            a.IdEstado = 1;
            a.Descripcion = "aaa";
            a.Marca = null;
            a.Foto = null;

            if (a.IdArticulo == 1)
            {
                result = "pass";
            }
            else
            {
                result = "fail";
            }
            Assert.AreEqual(result, "pass");


        }//CreateArticuloTest

        [TestMethod]
        public void CreateReporteEntregadoTest()
        {
            ReporteEntregado a = new ReporteEntregado();
            var result = "";
            if (a.IdEntrega == 1)
            {
                result = "pass";
            }
            else
            {
                result = "fail";
            }
            Assert.AreEqual(result, "fail"); // prueba donde no se ha creado articulo

            a.IdEntrega = 1;
            a.IdUsuario = 1;
            a.Fecha = new DateTime(2018,11,1);
            a.IdArticulo = 1;
            a.Celular = 99113322;
            a.Email = "aaa";

            if (a.IdEntrega == 1)
            {
                result = "pass";
            }
            else
            {
                result = "fail";
            }
            Assert.AreEqual(result, "pass");


        }//CreateReporteEntregadoTest

        [TestMethod]
        public void CreateCategoriaTest()
        {
            Categoria a = new Categoria();
            var result = "";
            if (a.IdCategoria == 1)
            {
                result = "pass";
            }
            else
            {
                result = "fail";
            }
            Assert.AreEqual(result, "fail"); // prueba donde no se ha creado articulo

            a.IdCategoria = 1;         
            a.Descripcion = "Articulo1";
         

            if (a.IdCategoria == 1)
            {
                result = "pass";
            }
            else
            {
                result = "fail";
            }
            Assert.AreEqual(result, "pass");


        }//CreateCategoriaTest


        [TestMethod]
        public void CreateReporteExtravioTest()
        {
            ReporteExtravio a = new ReporteExtravio();
            var result = "";
            if (a.IdReporte == 1)
            {
                result = "pass";
            }
            else
            {
                result = "fail";
            }
            Assert.AreEqual(result, "fail"); // prueba donde no se ha creado articulo

            a.IdReporte = 1;
            a.IdUsuario = 1;
            a.Fecha = new DateTime(2018, 11, 1);
            a.Descripcion = "aaa";
            a.Celular = "11002299";
            a.Email = "asds";
            a.NombreContacto = "Carlos";

            if (a.IdReporte == 1)
            {
                result = "pass";
            }
            else
            {
                result = "fail";
            }
            Assert.AreEqual(result, "pass");


        }//CreateArticuloTest


        [TestMethod]
        public void CreateUsuarioTest()
        {
            Usuario a = new Usuario();
            var result = "";
            if (a.idUsuario == 1)
            {
                result = "pass";
            }
            else
            {
                result = "fail";
            }
            Assert.AreEqual(result, "fail"); // prueba donde no se ha creado articulo

            a.idUsuario = 1;
            a.Nombre = "nombre";
            a.Apellido1 = "apellido";
            a.Apellido2 = "apellido";
            a.Contrasenia = "99113322";
            a.IdRol = 1;

            if (a.idUsuario == 1)
            {
                result = "pass";
            }
            else
            {
                result = "fail";
            }
            Assert.AreEqual(result, "pass");
        }//CreateUsuarioTest



        //Busquedas
        [TestMethod]
        public void BusquedaCategoriaTest()
        {
            Articulo[] ar = new Articulo[15];
            var result = "";
            for (int i = 0; i < 15; i++)
            {
                ar[i] = new Articulo();
                ar[i].IdArticulo = i;
                ar[i].IdCategoria = i;
                ar[i].IdEstado = i;
                ar[i].Descripcion = "aaa" + i;
                ar[i].Marca = null;
                ar[i].Foto = null;
            }
            for (int j = 0; j < 15; j++)
            {
                if (ar[j].IdCategoria == 6)
                {
                    result = "pass";
                }
            }
            Assert.AreEqual(result, "pass");
        }//BusquedaCategoriaTest

        [TestMethod]
        public void BusquedaPorFechaTest()
        {
            ReporteEntregado[] rp = new ReporteEntregado[15];
            string result = "";
            DateTime Now = new DateTime();
            Now = new DateTime(2018, 11, 30);
            for (int i = 0; i < 15; i++)
            {
                rp[i] = new ReporteEntregado();
                rp[i].IdEntrega = i;
                rp[i].IdUsuario = i;
                rp[i].Fecha = Now.AddDays(i + 1);
                rp[i].IdArticulo = i;
                rp[i].Celular = null;
                rp[i].Email = "e";
            }
            DateTime FechaInicial = new DateTime(2018, 12, 2);
            DateTime FechaFinal = new DateTime(2018, 12, 6);

            for (int j = 0; j < 15; j++)
            {
                if (rp[j].Fecha >= FechaInicial && rp[j].Fecha <= FechaFinal)
                {
                    result = result + rp[j].Fecha.ToString() + " ";
                }
            }
            Assert.AreEqual(result, "02/12/2018 0:00:00 03/12/2018 0:00:00 04/12/2018 0:00:00 05/12/2018 0:00:00 06/12/2018 0:00:00 ");
        }//BusquedaPorFechaTest
    }
}
