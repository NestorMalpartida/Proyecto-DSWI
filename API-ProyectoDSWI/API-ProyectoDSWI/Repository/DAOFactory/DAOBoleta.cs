using API_ProyectoDSWI.Models;
using API_ProyectoDSWI.Repository.Interface;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_ProyectoDSWI.Repository.DAOFactory
{
    public class DAOBoleta : BoletaInterface
    {
        private readonly string cadena;

        public DAOBoleta()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("sql");
        }

        public IEnumerable<BoletaDetalle> findAll()
        {
            List<BoletaDetalle> lista = new List<BoletaDetalle>();
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("usp_findAllBoletaDetalle", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                BoletaDetalle reg = new BoletaDetalle();
                reg.codigo = dr.GetInt32(0);
                reg.usuario = dr.GetString(1);
                reg.cliente = dr.GetString(2);
                reg.fechaEmision = dr.GetDateTime(3);
                reg.producto = dr.GetString(4);
                reg.totalPagar = Convert.ToDouble(dr.GetDecimal(5));

                lista.Add(reg);
            }
            dr.Close();
            cn.Close();

            return lista;
        }

        public BoletaDetalle findById(int codigo)
        {
            var m = findAll().Where(m => m.codigo == codigo).FirstOrDefault()!;
            if (m == null)
                return new BoletaDetalle();
            else
                return m;
        }

        public string save(Boleta b)
        {
            SqlConnection cn = new SqlConnection(cadena);
            int i = 0;
            string mensaje = "";
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_saveBoleta", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cod_usuario", b.codigoUsuario);
                cmd.Parameters.AddWithValue("@cod_cliente", b.codigoCliente);
                cmd.Parameters.AddWithValue("@fecha_emision", b.fechaEmision);
                cmd.Parameters.AddWithValue("@cod_producto", b.codigoProducto);
                cmd.Parameters.AddWithValue("@total_pagar", b.totalPagar);

                i = cmd.ExecuteNonQuery();

                mensaje = "Boleta registrada exitosamente - Cantidad de filas insertadas : " + i;

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
