using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Parcial3.Models;

namespace Parcial3.Data
{
    public class MunicipioData
    {
        public static bool Save(Municipio obodega)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Save_Municipio", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombreMunicipio", obodega.NombreMunicipio);
                cmd.Parameters.AddWithValue("@iddepartamento", obodega.Id_Departamento);

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
                SqlCommand cmd = new SqlCommand("Delete_Municipio", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idMunicipio", id);

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

        public static bool Edit(Municipio nMunicipio)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Edit_Municipio", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idMunicipio", nMunicipio.Id_Municipio);
                cmd.Parameters.AddWithValue("@nombreMunicipio", nMunicipio.NombreMunicipio);
                cmd.Parameters.AddWithValue("@iddepartamento", nMunicipio.Id_Departamento);

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

        public static Municipio Select(int id)
        {
            Municipio nMunicipio = new Municipio();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Select_Municipio", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idMunicipio", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            nMunicipio = new Municipio
                            {
                                Id_Municipio = Convert.ToInt32(dr["id_Municipio"]),
                                NombreMunicipio = dr["nombreMunicipio"].ToString(),
                                Id_Departamento = Convert.ToInt32(dr["id_Departamento"]),
                            };
                        }
                    }
                    oConexion.Close();
                    return nMunicipio;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static List<Municipio> SelectAll()
        {
            Municipio nMunicipio = new Municipio();
            List<Municipio> listaMunicipio = new List<Municipio>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("SelectAll_Municipio", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            nMunicipio = new Municipio
                            {
                                Id_Municipio = Convert.ToInt32(dr["id_Municipio"]),
                                NombreMunicipio = dr["nombreMunicipio"].ToString(),
                                Id_Departamento = Convert.ToInt32(dr["id_Departamento"]),
                            };
                            listaMunicipio.Add(nMunicipio);
                        }
                    }
                    oConexion.Close();
                    return listaMunicipio;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static List<Municipio> SelectByDepartamento(String nombreDepartamento)
        {
            Municipio nMunicipio = new Municipio();
            List<Municipio> listaMunicipio = new List<Municipio>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Municipio_ByDepartamento", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombreDepartamento", nombreDepartamento);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            nMunicipio = new Municipio
                            {
                                Id_Municipio = Convert.ToInt32(dr["id_Municipio"]),
                                NombreMunicipio = dr["nombreMunicipio"].ToString(),
                                Id_Departamento = Convert.ToInt32(dr["id_Departamento"]),
                            };
                            listaMunicipio.Add(nMunicipio);
                        }
                    }
                    oConexion.Close();
                    return listaMunicipio;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
