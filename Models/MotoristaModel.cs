namespace teste.Models
{
    public class MotoristaModels
    {
        public MotoristaModels()
        {
            list = new List<MotoristaModel>();
            item = new MotoristaModel();
        }

        public List<MotoristaModel> list { get; set; }
        public MotoristaModel item { get; set; }
    }

    public class MotoristaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string NumeroCNH { get; set; }
        public string CategoriaCNH { get; set; }
        public DateTime? DataNascimento { get; set; }
        public bool? Status { get; set; } // Ativo/Inativo
    }
}