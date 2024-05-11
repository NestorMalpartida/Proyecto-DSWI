using API_ProyectoDSWI.Models;
using API_ProyectoDSWI.Repository.Interface;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_ProyectoDSWI.Repository.DAOFactory
{
    public class DAOPais : PaisInterface
    {

        private readonly string cadena;

        public DAOPais()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("sql");
        }

        public IEnumerable<Pais> findAll()
        {
            List<Pais> lista = new List<Pais>();
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("usp_findAllPais", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Pais reg = new Pais();
                reg.codigo = dr.GetInt32(0);
                reg.descripcion = dr.GetString(1);

                lista.Add(reg);
            }
            dr.Close();
            cn.Close();

            return lista;
        }
    }
}
