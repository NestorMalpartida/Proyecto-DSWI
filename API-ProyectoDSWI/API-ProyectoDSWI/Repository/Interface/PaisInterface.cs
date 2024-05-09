using API_ProyectoDSWI.Models;

namespace API_ProyectoDSWI.Repository.Interface
{
    public interface PaisInterface
    {
        IEnumerable<Pais> findAll();
    }
}
