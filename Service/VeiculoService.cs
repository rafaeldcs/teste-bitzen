using teste.Entidade;
using teste.Repository.Interface;
using teste.Services.Interface;

namespace teste.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _repository;
        public VeiculoService(IVeiculoRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(Veiculo model)
        {
            await _repository.Create(model);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<List<Veiculo>> Search(Veiculo model)
        {
            return await _repository.Search(model);
        }

        public Veiculo Search(int id)
        {
            return _repository.Search(id);
        }

        public async Task Update(Veiculo model)
        {
            await _repository.Update(model);
        }
    }
}