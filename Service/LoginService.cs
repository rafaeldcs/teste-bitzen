using teste.Entidade;
using teste.Repository.Interface;
using teste.Services.Interface;

namespace teste.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _repository;

        public LoginService(ILoginRepository loginRepository)
        {
            _repository = loginRepository;
        }

        public Task<bool> CriarUsuario(Login login)
        {
            return _repository.CriarUsuario(login);
        }

        public async Task<bool> LogarSistema(Login login)
        {
            return await _repository.LogarSistema(login);
        }
    }
}