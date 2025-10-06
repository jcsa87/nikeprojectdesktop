using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using nikeproject.Models;
using nikeproject.DataAccess;

namespace nikeproject.Data
{
    public static class CategoriaData
    {
        public static List<Categoria> ListarCategorias()
        {
            List<Categoria> lista = new List<Categoria>();

            using (SqlConnection oConexion = Conexion.Conectar())
            {
                string query = "SELECT IdCategoria, Descripcion FROM CATEGORIA";
                SqlCommand cmd = new SqlCommand(query, oConexion);
                oConexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Categoria
                        {
                            IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                            Descripcion = dr["Descripcion"].ToString()
                        });
                    }
                }
            }

            return lista;
        }
    }
}
