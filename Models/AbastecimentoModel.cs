using Microsoft.AspNetCore.Mvc.Rendering;
using teste.Entidade;

namespace teste.Models
{
    public class AbastecimentoModels
    {
        public AbastecimentoModels()
        {
            list = new List<AbastecimentoModel>();
            item = new AbastecimentoModel();
            listVeiculo = new List<VeiculoModel>();
            listMotorista = new List<MotoristaModel>();
        }

        public List<AbastecimentoModel> list { get; set; }
        public List<VeiculoModel> listVeiculo { get; set; }
        public List<MotoristaModel> listMotorista { get; set; }
        public AbastecimentoModel item { get; set; }
    }

    public class AbastecimentoModel
    {
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public int MotoristaId { get; set; }
        public DateTime? Data { get; set; }
        public string TipoCombustivel { get; set; }
        public int QuantidadeAbastecida { get; set; }
        public decimal Total { get; set; }
        public Veiculo veiculo { get; set; }
        public Motorista Motorista { get; set; }
    }
}