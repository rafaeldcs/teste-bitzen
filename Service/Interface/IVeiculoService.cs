using teste.Entidade;

namespace teste.Services.Interface
{
    public interface IVeiculoService
    {
        Task Create(Veiculo model);
        Task Update(Veiculo model);
        Task<List<Veiculo>> Search(Veiculo model);
        Veiculo Search(int id);
        Task Delete(int id);
    }
}
