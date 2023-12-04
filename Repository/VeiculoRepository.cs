using Microsoft.EntityFrameworkCore;
using teste.Entidade;
using teste.Repository.Interface;

namespace teste.Repository
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly ApplicationDbContext _context;

        public VeiculoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Veiculo model)
        {
            _context.Veiculo.Add(model);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var veiculo = new Veiculo() { Id = id };

            _context.Veiculo.Remove(veiculo);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Veiculo>> Search(Veiculo model)
        {
            var query = _context.Veiculo.AsNoTracking();

            if (model != null)
            {
                if (model.Id != default)
                    query = query.Where(x => x.Id == model.Id);

                if (!string.IsNullOrEmpty(model.NomeVeiculo))
                    query = query.Where(x => x.NomeVeiculo.Equals(model.NomeVeiculo));

                if (!string.IsNullOrEmpty(model.Placa))
                    query = query.Where(x => x.Placa.Equals(model.Placa));

                if (!string.IsNullOrEmpty(model.TipoCombustivel))
                    query = query.Where(x => x.TipoCombustivel.Equals(model.TipoCombustivel));

                if (!string.IsNullOrEmpty(model.Fabricante))
                    query = query.Where(x => x.Fabricante.Equals(model.Fabricante));

                if (!string.IsNullOrEmpty(model.Observacoes))
                    query = query.Where(x => x.Observacoes.Equals(model.Observacoes));

                if (model.AnoFabricacao != default)
                    query = query.Where(x => x.AnoFabricacao == model.AnoFabricacao);

                if (model.CapacidadeTanque != default)
                    query = query.Where(x => x.CapacidadeTanque == model.CapacidadeTanque);
            }

            return await query.ToListAsync();
        }

        public Veiculo Search(int id, bool tracking = false)
        {
            var query = _context.Veiculo.Where(x => x.Id == id);

            if (tracking)
                query = query.AsTracking();

            return query.FirstOrDefault();
        }

        public async Task Update(Veiculo model)
        {
            _context.Entry(model).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}