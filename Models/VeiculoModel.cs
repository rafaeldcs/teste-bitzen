namespace teste.Models
{
    public class VeiculoModels
    {
        public VeiculoModels()
        {
            list = new List<VeiculoModel>();
            item = new VeiculoModel();
        }

        public List<VeiculoModel> list { get; set; }
        public VeiculoModel item { get; set; }
    }
    public class VeiculoModel
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string NomeVeiculo { get; set; }
        public string TipoCombustivel { get; set; }
        public string Fabricante { get; set; }
        public int AnoFabricacao { get; set; }
        public int CapacidadeTanque { get; set; }
        public string Observacoes { get; set; }
    }
}