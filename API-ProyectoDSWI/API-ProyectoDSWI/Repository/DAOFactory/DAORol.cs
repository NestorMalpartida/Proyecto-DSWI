using API_ProyectoDSWI.Models;
using API_ProyectoDSWI.Repository.Interface;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_ProyectoDSWI.Repository.DAOFactory
{
    public class DAORol : RolInterface
    {
        private readonly string cadena;

        public DAORol()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("sql");
        }

        public IEnumerable<Rol> findAll()
        {
            List<Rol> lista = new List<Rol>();
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("usp_findAllRol", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Rol reg = new Rol();
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
