using API_ProyectoDSWI.Models;

namespace API_ProyectoDSWI.Repository.Interface
{
    public interface BoletaInterface
    {
        IEnumerable<BoletaDetalle> findAll();
        BoletaDetalle findById(int codigo);
        string save(Boleta b);
    }
}
