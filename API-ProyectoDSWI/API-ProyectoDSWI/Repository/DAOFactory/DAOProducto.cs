using API_ProyectoDSWI.Models;
using API_ProyectoDSWI.Repository.Interface;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_ProyectoDSWI.Repository.DAOFactory
{
    public class DAOProducto : ProductoInterface
    {
        private readonly string cadena;

        public DAOProducto()
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
                SqlCommand cmd = new SqlCommand("usp_deleteProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cod_producto", codigo);

                i = cmd.ExecuteNonQuery();

                mensaje = "Producto eliminado satisfacotiramente - Cantidad de filas eliminadas : " + i;
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

        public IEnumerable<Producto> findAll()
        {
            List<Producto> lista = new List<Producto>();
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("usp_findAllProducto", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Producto reg = new Producto();
                reg.codigo = dr.GetInt32(0);
                reg.nombre = dr.GetString(1);
                reg.descripcion = dr.GetString(2);
                reg.codigoMarca = dr.GetInt32(3);
                reg.precio = Convert.ToDouble(dr.GetDecimal(4));

                lista.Add(reg);
            }
            dr.Close();
            cn.Close();

            return lista;
        }

        public IEnumerable<ProductoDetalle> findAllProductoDetalle()
        {
            List<ProductoDetalle> lista = new List<ProductoDetalle>();
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("usp_findAllProductoDetalle", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ProductoDetalle reg = new ProductoDetalle();
                reg.codigo = dr.GetInt32(0);
                reg.nombre = dr.GetString(1);
                reg.descripcion = dr.GetString(2);
                reg.marca = dr.GetString(3);
                reg.precio = Convert.ToDouble(dr.GetDecimal(4));

                lista.Add(reg);
            }
            dr.Close();
            cn.Close();

            return lista;
        }

        public Producto findById(int codigo)
        {
            var c = findAll().Where(c => c.codigo == codigo).FirstOrDefault()!;
            if (c == null)
                return new Producto();
            else
                return c;
        }

        public ProductoDetalle findByIdProductoDetalle(int codigo)
        {
            var cd = findAllProductoDetalle().Where(cd => cd.codigo == codigo).FirstOrDefault()!;
            if (cd == null)
                return new ProductoDetalle();
            else
                return cd;
        }

        public string save(Producto p)
        {
            SqlConnection cn = new SqlConnection(cadena);
            int i = 0;
            string mensaje = "";
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_saveProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre", p.nombre);
                cmd.Parameters.AddWithValue("@descripcion", p.descripcion);
                cmd.Parameters.AddWithValue("@cod_marca", p.codigoMarca);
                cmd.Parameters.AddWithValue("@precio", p.precio);

                i = cmd.ExecuteNonQuery();

                mensaje = "Producto registrado exitosamente - Cantidad de filas insertadas : " + i;

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

        public string update(Producto p)
        {
            SqlConnection cn = new SqlConnection(cadena);
            int i = 0;
            string mensaje = "";
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_updateProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cod_producto", p.codigo);
                cmd.Parameters.AddWithValue("@nombre", p.nombre);
                cmd.Parameters.AddWithValue("@descripcion", p.descripcion);
                cmd.Parameters.AddWithValue("@cod_marca", p.codigoMarca);
                cmd.Parameters.AddWithValue("@precio", p.precio);

                i = cmd.ExecuteNonQuery();

                mensaje = "Producto actualizado exitosamente - Cantidad de filas actualizadas : " + i;

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
