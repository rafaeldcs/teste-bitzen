using Microsoft.EntityFrameworkCore;
using teste.Entidade;
using teste.Repository.Interface;

namespace teste.Repository
{
    public class AbastecimentoRepository : IAbastecimentoRepository
    {
        private readonly ApplicationDbContext _context;

        public AbastecimentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Abastecimento model)
        {
            _context.Abastecimento.Add(model);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var abastecimento = new Abastecimento() { Id = id };

            _context.Abastecimento.Remove(abastecimento);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Abastecimento>> Search(Abastecimento model)
        {
            var query = _context.Abastecimento.Include(x => x.Motorista).Include(x => x.veiculo).AsNoTracking();

            if (model != null)
            {
                if (model.Id != default)
                    query = query.Where(x => x.Id == model.Id);

                if (model.VeiculoId != default)
                    query = query.Where(x => x.VeiculoId == model.VeiculoId);

                if (model.MotoristaId != default)
                    query = query.Where(x => x.MotoristaId == model.MotoristaId);

                if (model.QuantidadeAbastecida != default)
                    query = query.Where(x => x.QuantidadeAbastecida == model.QuantidadeAbastecida);

                if (model.Total != default)
                    query = query.Where(x => x.Total == model.Total);

                if (model.Data != null)
                    query = query.Where(x => x.Data <= model.Data);

                if (!string.IsNullOrEmpty(model.TipoCombustivel))
                    query = query.Where(x => x.TipoCombustivel.Equals(model.TipoCombustivel));
            }

            return await query.ToListAsync();
        }

        public async Task<Abastecimento> Search(int id)
        {
            return await _context.Abastecimento.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Update(Abastecimento model)
        {
            _context.Entry(model).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}