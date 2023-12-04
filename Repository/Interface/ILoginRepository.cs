using teste.Entidade;

namespace teste.Repository.Interface
{
    public interface ILoginRepository
    {
        Task<bool> LogarSistema(Login login);
        Task<bool> CriarUsuario(Login login);
    }
}
