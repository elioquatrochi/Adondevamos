using Adondevamos.Models;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;

namespace Adondevamos.Datoss
{
    public class ContactoDatos
    {
        string sqlc = ("Data Source=Elio;Initial Catalog=Login;Integrated Security=True");

        public List<ContactoModel> Listar() { 
        

            var oLista = new List<ContactoModel>();

            var cn = new Conexion();

            using (SqlConnection connection = new SqlConnection(sqlc))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("Listar", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader()) {

                    while (dr.Read()) {
                        oLista.Add(new ContactoModel() {
                            IdContacto = Convert.ToInt32(dr["IdContacto"]),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString()
                        });

                    }
                }
            }

            return oLista;
        }

        public ContactoModel Obtener(int IdContacto)
        {

            var oContacto = new ContactoModel();

            var cn = new Conexion();

            using (SqlConnection connection = new SqlConnection(sqlc))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("Obtener", connection);
                cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oContacto.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                        oContacto.Nombre = dr["Nombre"].ToString();
                        oContacto.Telefono = dr["Telefono"].ToString();
                        oContacto.Correo = dr["Correo"].ToString();
                    }
                }
            }

            return oContacto;
        }

        public bool Guardar(ContactoModel obe)
        {
            bool rpta;
            string sqlsentecia = "Agregar";
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = sqlc;

            try { 

            SqlCommand comm = new SqlCommand(sqlsentecia, conn);
            comm.CommandType = CommandType.StoredProcedure;
           
            comm.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = obe.Nombre;
            comm.Parameters.Add("@Telefono", SqlDbType.NVarChar).Value = obe.Telefono;
            comm.Parameters.Add("@Correo", SqlDbType.NVarChar).Value = obe.Correo;

            conn.Open();
          


            rpta = true;

          
        }
            catch (Exception e) {

                string error = e.Message;
        rpta = false;

            }



            return rpta;
           

        }

        public bool Editar(ContactoModel ocontacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (SqlConnection connection = new SqlConnection(sqlc))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", connection);
                    cmd.Parameters.AddWithValue("IdContacto", ocontacto.IdContacto);
                    cmd.Parameters.AddWithValue("Nombre", ocontacto.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", ocontacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo", ocontacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

        public bool Eliminar(int IdContacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (SqlConnection connection = new SqlConnection(sqlc))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", connection);
                    cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }


    }
}
