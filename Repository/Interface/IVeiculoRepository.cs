using teste.Entidade;

namespace teste.Repository.Interface
{
    public interface IVeiculoRepository
    {
        Task Create(Veiculo model);
        Task Update(Veiculo model);
        Task<List<Veiculo>> Search(Veiculo model);
        Veiculo Search(int id, bool tracking = false);
        Task Delete(int id);
    }
}
