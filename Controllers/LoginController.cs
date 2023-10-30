using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

using Adondevamos.Models;

using System.Data.SqlClient;
using System.Data;

namespace AdondeVamos.Controllers
{
    public class LoginController : Controller
    {

        // GET: Login
        static string cadena = @"Data Source=Elio;Initial Catalog=login1;Integrated Security=True";



        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }
       
        public ActionResult Registrar()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Registrar(Login oUsuario)
        {
            bool registrado;
            string mensaje;

            //if (oUsuario.Clave == oUsuario.ConfirmarClave)
            //{

            //    oUsuario.Clave = ConvertirSha256(oUsuario.Clave);
            //}
            //else
            //{
            //    ViewData["Mensaje"] = "Las contraseñas no coinciden";
            //    return View();
            //}

            using (SqlConnection cn = new SqlConnection(cadena))
            {

                SqlCommand cmd = new SqlCommand("Sp_registrarUsuario", cn);
                cmd.Parameters.AddWithValue("Correo", oUsuario.Correo);
                cmd.Parameters.AddWithValue("Clave", oUsuario.Clave);
                cmd.Parameters.Add("Registrado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                cmd.ExecuteNonQuery();

                registrado = Convert.ToBoolean(cmd.Parameters["Registrado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();


            }

            ViewData["Mensaje"] = mensaje;

            if (registrado)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return View();
            }

        }




        [HttpPost]
        public ActionResult Login(Login oUsuario)
        {
            if (oUsuario.Clave == null || oUsuario.Correo == null)
            {
                ViewData["Mensaje"] = "Llene todos los campos";
                return View();
            }
            else
                //{
                //    oUsuario.Clave = ConvertirSha256(oUsuario.Clave);



                using (SqlConnection cn = new SqlConnection(cadena))
                {
                    SqlCommand cmd = new SqlCommand("Sp_ValidarUsuario", cn);
                    cmd.Parameters.AddWithValue("Correo", oUsuario.Correo);
                    cmd.Parameters.AddWithValue("Clave", oUsuario.Clave);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();
                 

                        oUsuario.Idusuario = Convert.ToInt32(cmd.ExecuteScalar().ToString());


                    



                }

          

            if (oUsuario.Idusuario != 0)
                    {

                Session["usuario"] = oUsuario;
                return RedirectToAction("Principal","Principal");

            }

                    else
            {
                ViewData["Mensaje"] = "Usuario o Contraseña incorrectas";
                return View();
                

            }
           
        }
    }
}









