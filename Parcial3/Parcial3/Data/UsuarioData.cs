using Parcial3.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Parcial3.Data
{
    public class UsuarioData
    {

        public static bool Save(Usuario nUsuario)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Save_Usuario", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombreUsuario", nUsuario.NombreUsuario);

                cmd.Parameters.AddWithValue("@passwordsuario", Encriptar.GetSHA256(nUsuario.PasswordUsuario));
                


                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    oConexion.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool Delete(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Delete_Usuario", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idUsuario", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    oConexion.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool Edit(Usuario nUsuario)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Edit_Usuario", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idUsuario", nUsuario.Id_Usuario);
                cmd.Parameters.AddWithValue("@nombreUsuario", nUsuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@passwordUsuario", nUsuario.PasswordUsuario);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    oConexion.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static Usuario Select(int id)
        {
            Usuario nUsuario = new Usuario();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Select_Usuario", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idUsuario", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            nUsuario = new Usuario
                            {
                                Id_Usuario = Convert.ToInt32(dr["id_Usuario"]),
                                NombreUsuario = dr["nombreUsuario"].ToString(),
                                PasswordUsuario =dr["passwordUsuario"].ToString(),
                            };
                        }
                    }
                    oConexion.Close();
                    return nUsuario;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static List<Usuario> SelectAll()
        {
            Usuario nUsuario = new Usuario();
            List<Usuario> listaUsuario = new List<Usuario>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("SelectAll_Usuario", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            nUsuario = new Usuario
                            {
                                Id_Usuario = Convert.ToInt32(dr["id_Usuario"]),
                                NombreUsuario = dr["nombreUsuario"].ToString(),
                                PasswordUsuario =dr["passwordUsuario"].ToString(),
                            };
                            listaUsuario.Add(nUsuario);
                        }
                    }
                    oConexion.Close();
                    return listaUsuario;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}