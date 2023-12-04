using teste.Entidade;

namespace teste.Repository.Interface
{
    public interface IAbastecimentoRepository
    {
        Task Create(Abastecimento model);
        Task Update(Abastecimento model);
        Task<List<Abastecimento>> Search(Abastecimento model);
        Task<Abastecimento> Search(int id);
        Task Delete(int id);
    }
}
