using API_ProyectoDSWI.Models;

namespace API_ProyectoDSWI.Repository.Interface
{
    public interface UsuarioInterface
    {
        IEnumerable<Usuario> findAll();
        Usuario findById(int codigo);
        string save(Usuario u);
        string update(Usuario u);
        string deleteById(int codigo);
        IEnumerable<UsuarioDetalle> findAllUsuarioDetalle();
        UsuarioDetalle findByIdUsuarioDetalle(int codigo);
    }
}
