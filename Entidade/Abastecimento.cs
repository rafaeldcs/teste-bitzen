namespace teste.Entidade
{
    public class Abastecimento
    {
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public int MotoristaId { get; set; }
        public DateTime? Data { get; set; }
        public string TipoCombustivel { get; set; }
        public int QuantidadeAbastecida { get; set; }
        public decimal Total { get; set; }

        public virtual Veiculo veiculo { get; set; }
        public virtual Motorista Motorista { get; set; }
    }
}