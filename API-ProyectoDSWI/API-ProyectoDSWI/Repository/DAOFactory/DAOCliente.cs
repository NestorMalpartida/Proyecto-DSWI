using API_ProyectoDSWI.Models;
using API_ProyectoDSWI.Repository.Interface;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_ProyectoDSWI.Repository.DAOFactory
{
    public class DAOCliente : ClienteInterface
    {
        private readonly string cadena;

        public DAOCliente()
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
                SqlCommand cmd = new SqlCommand("usp_deleteCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cod_cliente", codigo);

                i = cmd.ExecuteNonQuery();

                mensaje = "Cliente eliminado satisfacotiramente - Cantidad de filas eliminadas : " + i;
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

        public IEnumerable<Cliente> findAll()
        {
            List<Cliente> lista = new List<Cliente>();
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("usp_findAllCliente", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cliente reg = new Cliente();
                reg.codigo = dr.GetInt32(0);
                reg.codigoUsuario = dr.GetInt32(1);
                reg.codigoDistrito = dr.GetInt32(2);
                reg.direccion = dr.GetString(3);

                lista.Add(reg);
            }
            dr.Close();
            cn.Close();

            return lista;
        }

        public IEnumerable<ClienteDetalle> findAllClienteDetalle()
        {
            List<ClienteDetalle> lista = new List<ClienteDetalle>();
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("usp_findAllClienteDetalle", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ClienteDetalle reg = new ClienteDetalle();
                reg.codigo = dr.GetInt32(0);
                reg.usuario = dr.GetString(1);
                reg.distrito = dr.GetString(2);
                reg.direccion = dr.GetString(3);

                lista.Add(reg);
            }
            dr.Close();
            cn.Close();

            return lista;
        }

        public Cliente findById(int codigo)
        {
            var c = findAll().Where(c => c.codigo == codigo).FirstOrDefault()!;
            if (c == null)
                return new Cliente();
            else
                return c;
        }

        public ClienteDetalle findByIdClienteDetalle(int codigo)
        {
            var cd = findAllClienteDetalle().Where(cd => cd.codigo == codigo).FirstOrDefault()!;
            if (cd == null)
                return new ClienteDetalle();
            else
                return cd;
        }

        public string save(Cliente c)
        {
            SqlConnection cn = new SqlConnection(cadena);
            int i = 0;
            string mensaje = "";
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_saveCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cod_usuario", c.codigoUsuario);
                cmd.Parameters.AddWithValue("@cod_distrito", c.codigoDistrito);
                cmd.Parameters.AddWithValue("@direccion", c.direccion);

                i = cmd.ExecuteNonQuery();

                mensaje = "Cliente registrado exitosamente - Cantidad de filas insertadas : " + i;

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

        public string update(Cliente c)
        {
            SqlConnection cn = new SqlConnection(cadena);
            int i = 0;
            string mensaje = "";
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_updateCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cod_cliente", c.codigo);
                cmd.Parameters.AddWithValue("@cod_usuario", c.codigoUsuario);
                cmd.Parameters.AddWithValue("@cod_distrito", c.codigoDistrito);
                cmd.Parameters.AddWithValue("@direccion", c.direccion);

                i = cmd.ExecuteNonQuery();

                mensaje = "Cliente actualizado exitosamente - Cantidad de filas actualizadas : " + i;

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
