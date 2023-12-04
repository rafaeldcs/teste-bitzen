using teste.Entidade;

namespace teste.Services.Interface
{
    public interface ILoginService
    {
        Task<bool> LogarSistema(Login login);
        Task<bool> CriarUsuario(Login login);
    }
}
