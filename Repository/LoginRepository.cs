using Microsoft.EntityFrameworkCore;
using teste.Entidade;
using teste.Repository.Interface;

namespace teste.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ApplicationDbContext _context;

        public LoginRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CriarUsuario(Login login)
        {
            _context.Login.Add(login);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> LogarSistema(Login login)
        {
            return await _context.Login.Where(x => x.Usuario.Equals(login.Usuario) && x.Senha.Equals(login.Senha)).FirstOrDefaultAsync() != null;
        }
    }
}