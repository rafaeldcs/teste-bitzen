using teste.Entidade;
using teste.Repository.Interface;
using teste.Services.Interface;

namespace teste.Services
{
    public class MotoristaService : IMotoristaService
    {
        private readonly IMotoristaRepository _repository;
        public MotoristaService(IMotoristaRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(Motorista model)
        {
            await _repository.Create(model);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<List<Motorista>> Search(Motorista model)
        {
            return await _repository.Search(model);
        }

        public async Task<Motorista> Search(int id)
        {
            return await _repository.Search(id);
        }

        public async Task Update(Motorista model)
        {
            await _repository.Update(model);
        }
    }
}