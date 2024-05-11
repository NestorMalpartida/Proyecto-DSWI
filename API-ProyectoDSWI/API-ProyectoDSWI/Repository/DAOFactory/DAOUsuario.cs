using API_ProyectoDSWI.Models;
using API_ProyectoDSWI.Repository.Interface;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_ProyectoDSWI.Repository.DAOFactory
{
    public class DAOUsuario : UsuarioInterface
    {
        private readonly string cadena;

        public DAOUsuario()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("sql");
        }

        public string deleteById(int codigo)
        {
            SqlConnection cn = new SqlConnection(cadena);
            int i = 0;
            String mensaje = "";
            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("usp_deleteUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cod_usuario", codigo);

                i = cmd.ExecuteNonQuery();

                mensaje = "Usuario eliminado satisfacotiramente - Cantidad de filas eliminadas : " + i;
            }
            catch (SqlException e)
            {
                mensaje = e.Message;
                throw;
            }
            finally
            {
                cn.Close();
            }
            return mensaje;
        }

        public IEnumerable<Usuario> findAll()
        {
            List<Usuario> lista = new List<Usuario>();
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("usp_findAllUsuario", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Usuario reg = new Usuario();
                reg.codigo = dr.GetInt32(0);
                reg.codigoRol = dr.GetInt32(1);
                reg.correo = dr.GetString(2);
                reg.contrasena = dr.GetString(3);
                reg.nombre = dr.GetString(4);
                reg.dni = dr.GetString(5);
                reg.telefono = dr.GetString(6);

                lista.Add(reg);
            }
            dr.Close();
            cn.Close();

            return lista;
        }

        public IEnumerable<UsuarioDetalle> findAllUsuarioDetalle()
        {
            List<UsuarioDetalle> lista = new List<UsuarioDetalle>();
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("usp_findAllUsuarioDetalle", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                UsuarioDetalle reg = new UsuarioDetalle();
                reg.codigo = dr.GetInt32(0);
                reg.rol = dr.GetString(1);
                reg.correo = dr.GetString(2);
                reg.nombre = dr.GetString(3);
                reg.dni = dr.GetString(4);
                reg.telefono = dr.GetString(5);

                lista.Add(reg);
            }
            dr.Close();
            cn.Close();

            return lista;
        }
        public UsuarioDetalle findByIdUsuarioDetalle(int codigo)
        {
            var ud = findAllUsuarioDetalle().Where(ud => ud.codigo == codigo).FirstOrDefault()!;
            if (ud == null)
                return new UsuarioDetalle();
            else
                return ud;
        }

        public Usuario findById(int codigo)
        {
            var u = findAll().Where(u => u.codigo == codigo).FirstOrDefault()!;
            if (u == null)
                return new Usuario();
            else
                return u;
        }

        public string save(Usuario u)
        {
            SqlConnection cn = new SqlConnection(cadena);
            int i = 0;
            string mensaje = "";
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_saveUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cod_rol", u.codigoRol);
                cmd.Parameters.AddWithValue("@correo", u.correo);
                cmd.Parameters.AddWithValue("@contrasena", u.contrasena);
                cmd.Parameters.AddWithValue("@nombre", u.nombre);
                cmd.Parameters.AddWithValue("@dni", u.dni);
                cmd.Parameters.AddWithValue("@telefono", u.telefono);

                i = cmd.ExecuteNonQuery();

                mensaje = "Usuario registrado exitosamente - Cantidad de filas insertadas : " + i;

            }
            catch (SqlException e)
            {
                mensaje = e.Message;
                cn.Close();
                throw;
            }
            finally
            {
                cn.Close();
            }

            return mensaje;
        }

        public string update(Usuario u)
        {
            SqlConnection cn = new SqlConnection(cadena);
            int i = 0;
            string mensaje = "";
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_updateUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cod_usuario", u.codigo);
                cmd.Parameters.AddWithValue("@cod_rol", u.codigoRol);
                cmd.Parameters.AddWithValue("@correo", u.correo);
                cmd.Parameters.AddWithValue("@contrasena", u.contrasena);
                cmd.Parameters.AddWithValue("@nombre", u.nombre);
                cmd.Parameters.AddWithValue("@dni", u.dni);
                cmd.Parameters.AddWithValue("@telefono", u.telefono);

                i = cmd.ExecuteNonQuery();

                mensaje = "Usuario actualizado exitosamente - Cantidad de filas actualizadas : " + i;

            }
            catch (SqlException e)
            {
                mensaje = e.Message;
                cn.Close();
                throw;
            }
            finally
            {
                cn.Close();
            }

            return mensaje;
        }
    }
}
