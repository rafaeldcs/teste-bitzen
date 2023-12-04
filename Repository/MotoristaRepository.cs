using Microsoft.EntityFrameworkCore;
using teste.Entidade;
using teste.Repository.Interface;

namespace teste.Repository
{
    public class MotoristaRepository : IMotoristaRepository
    {
        private readonly ApplicationDbContext _context;

        public MotoristaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Motorista model)
        {
            _context.Motorista.Add(model);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var motorista = new Motorista() { Id = id };

            _context.Motorista.Remove(motorista);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Motorista>> Search(Motorista model)
        {
            var query = _context.Motorista.AsNoTracking();

            if (model != null)
            {
                if (model.Id != default)
                    query = query.Where(x => x.Id == model.Id);

                if (!string.IsNullOrEmpty(model.CPF))
                    query = query.Where(x => x.CPF.Equals(model.CPF));

                if (!string.IsNullOrEmpty(model.Nome))
                    query = query.Where(x => x.Nome.Equals(model.Nome));

                if (!string.IsNullOrEmpty(model.NumeroCNH))
                    query = query.Where(x => x.NumeroCNH.Equals(model.NumeroCNH));

                if (!string.IsNullOrEmpty(model.CategoriaCNH))
                    query = query.Where(x => x.CategoriaCNH.Equals(model.CategoriaCNH));

                if (model.DataNascimento != null)
                    query = query.Where(x => x.DataNascimento <= model.DataNascimento);

                if (model.Status != null)
                    query = query.Where(x => x.Status == model.Status);
            }

            return await query.ToListAsync();
        }

        public async Task<Motorista> Search(int id)
        {
            return await _context.Motorista.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task Update(Motorista model)
        {
            _context.Entry(model).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}