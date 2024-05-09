using API_ProyectoDSWI.Models;

namespace API_ProyectoDSWI.Repository.Interface
{
    public interface ProductoInterface
    {
        IEnumerable<Producto> findAll();
        Producto findById(int codigo);
        string save(Producto p);
        string update(Producto p);
        string deleteById(int codigo);
    }
}
