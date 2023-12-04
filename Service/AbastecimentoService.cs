using teste.Entidade;
using teste.Repository.Interface;
using teste.Services.Interface;

namespace teste.Services
{
    public class AbastecimentoService : IAbastecimentoService
    {
        private readonly PostoExemplo _posto = new PostoExemplo();
        private readonly IAbastecimentoRepository _repository;
        private readonly IVeiculoRepository _veiculoRepository;
        public AbastecimentoService(IAbastecimentoRepository repository, IVeiculoRepository veiculoRepository)
        {
            _repository = repository;
            _veiculoRepository = veiculoRepository;
        }

        public async Task<string> Create(Abastecimento model)
        {
            ValidaAbastecimento(model);

            model.Total = model.QuantidadeAbastecida * _posto.list.Where(x => x.TipoCombustivel.ToUpper().Equals(model.TipoCombustivel.ToUpper())).Select(x => x.preco).FirstOrDefault();

            await _repository.Create(model);

            return "ok";
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<List<Abastecimento>> Search(Abastecimento model)
        {
            return await _repository.Search(model);
        }

        public async Task<Abastecimento> Search(int id)
        {
            return await _repository.Search(id);
        }

        public async Task Update(Abastecimento model)
        {
            ValidaAbastecimento(model);

            model.Total = model.QuantidadeAbastecida * _posto.list.Where(x => x.TipoCombustivel.ToUpper().Equals(model.TipoCombustivel.ToUpper())).Select(x => x.preco).FirstOrDefault();

            await _repository.Update(model);
        }
        
        private void ValidaAbastecimento(Abastecimento model)
        {
            var veiculo = _veiculoRepository.Search(model.VeiculoId, false);

            if (model.QuantidadeAbastecida <= 0 || model.QuantidadeAbastecida > veiculo.CapacidadeTanque)
            {
                throw new Exception("Quantidade Abastecida está invalida");
            }

            if (!model.TipoCombustivel.Equals(veiculo.TipoCombustivel))
            {
                throw new Exception("Tipo de combustível inválido");
            }
        }
    }
}