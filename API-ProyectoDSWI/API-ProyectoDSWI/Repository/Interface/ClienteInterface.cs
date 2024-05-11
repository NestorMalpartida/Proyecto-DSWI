using API_ProyectoDSWI.Models;

namespace API_ProyectoDSWI.Repository.Interface
{
    public interface ClienteInterface
    {
        IEnumerable<Cliente> findAll();
        Cliente findById(int codigo);
        string save(Cliente c);
        string update(Cliente c);
        string deleteById(int codigo);
        IEnumerable<ClienteDetalle> findAllClienteDetalle();
        ClienteDetalle findByIdClienteDetalle(int codigo);
    }
}
