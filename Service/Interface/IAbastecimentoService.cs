using teste.Entidade;

namespace teste.Services.Interface
{
    public interface IAbastecimentoService
    {
        Task<string> Create(Abastecimento model);
        Task Update(Abastecimento model);
        Task<List<Abastecimento>> Search(Abastecimento model);
        Task<Abastecimento> Search(int id);
        Task Delete(int id);
    }
}
