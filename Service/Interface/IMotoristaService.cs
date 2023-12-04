using teste.Entidade;

namespace teste.Services.Interface
{
    public interface IMotoristaService
    {
        Task Create(Motorista model);
        Task Update(Motorista model);
        Task<List<Motorista>> Search(Motorista model);
        Task<Motorista> Search(int id);
        Task Delete(int id);
    }
}
