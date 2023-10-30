using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Adondevamos.Models;

namespace Adondevamos.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Perfil()
        {

            Perfil aperfil = new Perfil();



            string connectionString = "Data Source=Elio;Initial Catalog=Login;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("Listar", connection))
                {



                    command.CommandType = CommandType.StoredProcedure;
                    // Agrega los parámetros necesarios para el procedimiento almacenado, por ejemplo, el ID del usuario
                    command.Parameters.AddWithValue("@Id", aperfil.Id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Perfil usuario = new Perfil();
                            usuario.Nombre = reader["Nombre"].ToString();
                            //usuario.Apellido = reader["Apellido"].ToString();
                            //usuario.Email = reader["Email"].ToString();
                            // Asigna los valores de las otras propiedades del perfil de usuario según corresponda
                            return View(usuario);
                        }

                    }
                    return null;
                    
                }



              
            }

         
        // Otras acciones y propiedades del controlador

       

    

}
    }
}

