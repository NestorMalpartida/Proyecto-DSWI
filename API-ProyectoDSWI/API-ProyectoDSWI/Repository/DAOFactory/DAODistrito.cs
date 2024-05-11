using API_ProyectoDSWI.Models;
using API_ProyectoDSWI.Repository.Interface;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_ProyectoDSWI.Repository.DAOFactory
{
    public class DAODistrito : DistritoInterface
    {
        private readonly string cadena;

        public DAODistrito()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("sql");
        }

        public IEnumerable<Distrito> findAll()
        {
            List<Distrito> lista = new List<Distrito>();
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("usp_findAllDistrito", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Distrito reg = new Distrito();
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
