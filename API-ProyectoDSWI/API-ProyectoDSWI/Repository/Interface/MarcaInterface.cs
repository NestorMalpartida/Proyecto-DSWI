using API_ProyectoDSWI.Models;

namespace API_ProyectoDSWI.Repository.Interface
{
    public interface MarcaInterface
    {
        IEnumerable<Marca> findAll();
        Marca findById(int codigo);
        string save(Marca m);
        string update(Marca m);
        string deleteById(int codigo);
    }
}
