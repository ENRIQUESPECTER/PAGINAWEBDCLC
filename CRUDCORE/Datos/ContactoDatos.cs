using CRUDCORE.Models;
using System.Data.SqlClient;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using CRUDCORE.Controllers;
namespace CRUDCORE.Datos
{
    public class ContactoDatos : IBaseDatos
    {
        //Creacion del Metodo Listar
        public List<ContactoModel> Listar()
        {
            
            var oLista = new List<ContactoModel>();
            var cn = new Conexion();
            //Se obtiene la cadena de conexion
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                //Ejecucion del procedimiento almacenado sp_Listar
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    //Bucle que lee cada registro y los agrega
                    while (dr.Read())
                    {
                        oLista.Add(new ContactoModel()
                        {
                            IdContacto = Convert.ToInt32(dr["IdContacto"]),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Direccion = dr["Direccion"].ToString(),
                            FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"])
                        });
                    }
                }
            }
            return oLista;
        }
        //Creacion del Metodo Obtener
        public ContactoModel Obtener(int IdContacto)
        {
            var oContacto = new ContactoModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                //Ejecucion del procedimiento almacenado sp_Obtener
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("@IdContacto", IdContacto);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    //Bucle que lee los registros y los obtiene con id
                    while (dr.Read())
                    {
                        oContacto.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                        oContacto.Nombre = dr["Nombre"].ToString();
                        oContacto.Telefono = dr["Telefono"].ToString();
                        oContacto.Correo = dr["Correo"].ToString();
                        oContacto.Direccion = dr["Direccion"].ToString();
                        oContacto.FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"]);
                    }
                }
            }
            return oContacto;
        }
        //Creacion del Metodo Guardar
        public bool Guardar(ContactoModel oContacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    //Ejecucion del procedimiento almacenado sp_Guardar
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("@Nombre", oContacto.Nombre);
                    cmd.Parameters.AddWithValue("@Telefono", oContacto.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", oContacto.Correo);
                    cmd.Parameters.AddWithValue("@Direccion", oContacto.Direccion);
                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                return rpta = true;
            }
            //Excepcion en caso de haber error al insertar
            catch(Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }
        //Creacion del Metodo Editar
        public bool Editar(ContactoModel oContacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    //Ejecucion del procedimiento almacenado sp_Editar
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("@IdContacto", oContacto.IdContacto);
                    cmd.Parameters.AddWithValue("@Nombre", oContacto.Nombre);
                    cmd.Parameters.AddWithValue("@Telefono", oContacto.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", oContacto.Correo);
                    cmd.Parameters.AddWithValue("@Direccion", oContacto.Direccion);
                    cmd.Parameters.AddWithValue("@FechaCreacion", oContacto.FechaCreacion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                return rpta = true;
            }
            //Excepcion en caso de haber error al actualizar
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }
        //Creacion del Metodo Eliminar
        public bool Eliminar(int IdContacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    //Ejecucion del procedimiento almacenado sp_Eliminar
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("@IdContacto", IdContacto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                return rpta = true;
            }
            //Excepcion en caso de haber error al eliminar
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }
    }
}
