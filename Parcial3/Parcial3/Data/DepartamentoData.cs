using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Parcial3.Models;

namespace Parcial3.Data
{
    public class DepartamentoData
    {
        public static bool Save(Departamento obodega)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Save_Departamento", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombredepartamento", obodega.NombreDepartamento);

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
                SqlCommand cmd = new SqlCommand("Delete_Departamento", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@iddepartamento", id);

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

        public static bool Edit(Departamento nDepartamento)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Edit_Departamento", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@iddepartamento", nDepartamento.Id_Departamento);
                cmd.Parameters.AddWithValue("@nombredepartamento", nDepartamento.NombreDepartamento);

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

        public static Departamento Select(int id)
        {
            Departamento nDepartamento = new Departamento();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Select_Departamento", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@iddepartamento", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            nDepartamento = new Departamento
                            {
                                Id_Departamento = Convert.ToInt32(dr["id_Departamento"]),
                                NombreDepartamento = dr["nombredepartamento"].ToString(),
                            };
                        }
                    }
                    oConexion.Close();
                    return nDepartamento;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static List<Departamento> SelectAll()
        {
            Departamento nDepartamento = new Departamento();
            List<Departamento> listaDepartamento = new List<Departamento>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("SelectAll_Departamento", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            nDepartamento = new Departamento
                            {
                                Id_Departamento = Convert.ToInt32(dr["id_Departamento"]),
                                NombreDepartamento = dr["nombredepartamento"].ToString(),
                            };
                            listaDepartamento.Add(nDepartamento);
                        }
                    }
                    oConexion.Close();
                    return listaDepartamento;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
