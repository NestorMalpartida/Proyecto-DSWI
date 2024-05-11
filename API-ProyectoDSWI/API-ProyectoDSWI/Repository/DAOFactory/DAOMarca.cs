using API_ProyectoDSWI.Models;
using API_ProyectoDSWI.Repository.Interface;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_ProyectoDSWI.Repository.DAOFactory
{
    public class DAOMarca : MarcaInterface
    {
        private readonly string cadena;

        public DAOMarca()
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
                SqlCommand cmd = new SqlCommand("usp_deleteMarca", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cod_marca", codigo);

                i = cmd.ExecuteNonQuery();

                mensaje = "Marca eliminada satisfacotiramente - Cantidad de filas eliminadas : " + i;
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

        public IEnumerable<Marca> findAll()
        {
            List<Marca> lista = new List<Marca>();
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("usp_findAllMarca", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Marca reg = new Marca();
                reg.codigo = dr.GetInt32(0);
                reg.descripcion = dr.GetString(1);
                reg.codigoPais = dr.GetInt32(2);
                reg.ruc = dr.GetString(3);
                reg.telefono = dr.GetString(4);
                reg.correo = dr.GetString(5);

                lista.Add(reg);
            }
            dr.Close();
            cn.Close();

            return lista;
        }

        public IEnumerable<MarcaDetalle> findAllMarcaDetalle()
        {
            List<MarcaDetalle> lista = new List<MarcaDetalle>();
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("usp_findAllMarcaDetalle", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                MarcaDetalle reg = new MarcaDetalle();
                reg.codigo = dr.GetInt32(0);
                reg.descripcion = dr.GetString(1);
                reg.pais = dr.GetString(2);
                reg.ruc = dr.GetString(3);
                reg.telefono = dr.GetString(4);
                reg.correo = dr.GetString(5);

                lista.Add(reg);
            }
            dr.Close();
            cn.Close();

            return lista;
        }

        public Marca findById(int codigo)
        {
            var m = findAll().Where(m => m.codigo == codigo).FirstOrDefault()!;
            if (m == null)
                return new Marca();
            else
                return m;
        }

        public MarcaDetalle findByIdMarcaDetalle(int codigo)
        {
            var md = findAllMarcaDetalle().Where(md => md.codigo == codigo).FirstOrDefault()!;
            if (md == null)
                return new MarcaDetalle();
            else
                return md;
        }

        public string save(Marca m)
        {
            SqlConnection cn = new SqlConnection(cadena);
            int i = 0;
            string mensaje = "";
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_saveMarca", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@descripcion", m.descripcion);
                cmd.Parameters.AddWithValue("@cod_pais", m.codigoPais);
                cmd.Parameters.AddWithValue("@ruc", m.ruc);
                cmd.Parameters.AddWithValue("@telefono", m.telefono);
                cmd.Parameters.AddWithValue("@correo", m.correo);

                i = cmd.ExecuteNonQuery();

                mensaje = "Marca registrada exitosamente - Cantidad de filas insertadas : " + i;

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

        public string update(Marca m)
        {
            SqlConnection cn = new SqlConnection(cadena);
            int i = 0;
            string mensaje = "";
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_updateMarca", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cod_marca", m.codigo);
                cmd.Parameters.AddWithValue("@descripcion", m.descripcion);
                cmd.Parameters.AddWithValue("@cod_pais", m.codigoPais);
                cmd.Parameters.AddWithValue("@ruc", m.ruc);
                cmd.Parameters.AddWithValue("@telefono", m.telefono);
                cmd.Parameters.AddWithValue("@correo", m.correo);

                i = cmd.ExecuteNonQuery();

                mensaje = "Marca actualizada exitosamente - Cantidad de filas actualizadas : " + i;

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
