using API_ProyectoDSWI.Models;

namespace API_ProyectoDSWI.Repository.Interface
{
    public interface BoletaInterface
    {
        IEnumerable<Boleta> findAll();
        Boleta findById(int codigo);
        string save(Boleta b);
        string update(Boleta b);
        string deleteById(int codigo);
    }
}
