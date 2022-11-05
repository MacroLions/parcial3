using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Parcial3.Models;

namespace Parcial3.Data
{
    public class EmpleadoData
    {
        public static bool Save(Empleado nEmpleado)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Save_Empleado", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombreEmpleado", nEmpleado.NombreEmpleado);
                cmd.Parameters.AddWithValue("@apellidoEmpleado", nEmpleado.ApellidoEmpleado);
                cmd.Parameters.AddWithValue("@genero", nEmpleado.Genero);
                cmd.Parameters.AddWithValue("@direccion", nEmpleado.Direccion);
                cmd.Parameters.AddWithValue("@telefono", nEmpleado.Telefono);
                cmd.Parameters.AddWithValue("@activo", nEmpleado.Activo);
                cmd.Parameters.AddWithValue("@codigo", nEmpleado.Codigo);
                cmd.Parameters.AddWithValue("@salario", nEmpleado.Salario);

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
                SqlCommand cmd = new SqlCommand("Delete_Empleado", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idEmpleado", id);

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

        public static bool Edit(Empleado nEmpleado)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Edit_Empleado", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idEmpleado", nEmpleado.Id_Empleado);
                cmd.Parameters.AddWithValue("@nombreEmpleado", nEmpleado.NombreEmpleado);
                cmd.Parameters.AddWithValue("@apellidoEmpleado", nEmpleado.ApellidoEmpleado);
                cmd.Parameters.AddWithValue("@genero", nEmpleado.Genero);
                cmd.Parameters.AddWithValue("@direccion", nEmpleado.Direccion);
                cmd.Parameters.AddWithValue("@telefono", nEmpleado.Telefono);
                cmd.Parameters.AddWithValue("@activo", nEmpleado.Activo);
                cmd.Parameters.AddWithValue("@codigo", nEmpleado.Codigo);
                cmd.Parameters.AddWithValue("@salario", nEmpleado.Salario);

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

        public static Empleado Select(int id)
        {
            Empleado nEmpleado = new Empleado();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Select_Empleado", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idempleado", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            nEmpleado = new Empleado
                            {
                                Id_Empleado = Convert.ToInt32(dr["id_Empleado"]),
                                NombreEmpleado = dr["nombreEmpleado"].ToString(),
                                ApellidoEmpleado = dr["apellidoEmpleado"].ToString(),
                                Genero = dr["genero"].ToString(),
                                Direccion = dr["direccion"].ToString(),
                                Telefono = dr["telefono"].ToString(),
                                Activo = Convert.ToInt32(dr["activo"]),
                                Codigo = dr["codigo"].ToString(),
                                Salario = Convert.ToSingle(dr["salario"]),
                            };
                        }
                    }
                    oConexion.Close();
                    return nEmpleado;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static List<Empleado> SelectAll()
        {
            Empleado nEmpleado = new Empleado();
            List<Empleado> listaEmpleado = new List<Empleado>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("SelectAll_Empleado", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            nEmpleado = new Empleado
                            {
                                Id_Empleado = Convert.ToInt32(dr["id_Empleado"]),
                                NombreEmpleado = dr["nombreEmpleado"].ToString(),
                                ApellidoEmpleado = dr["apellidoEmpleado"].ToString(),
                                Genero = dr["genero"].ToString(),
                                Direccion = dr["direccion"].ToString(),
                                Telefono = dr["telefono"].ToString(),
                                Activo = Convert.ToInt32(dr["activo"]),
                                Codigo = dr["codigo"].ToString(),
                                Salario = Convert.ToSingle(dr["salario"]),
                            };
                            listaEmpleado.Add(nEmpleado);
                        }
                    }
                    oConexion.Close();
                    return listaEmpleado;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static bool ActivarEmpleado(int id,String razon)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Activar_Empleado", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idEmpleado", id);
                cmd.Parameters.AddWithValue("@razon", razon);

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

        public static bool DesactivarEmpleado(int id,String razon)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Desactivar_Empleado", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idEmpleado", id);
                cmd.Parameters.AddWithValue("@razon", razon);

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
    }
}
