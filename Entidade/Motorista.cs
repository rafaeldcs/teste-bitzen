using System.ComponentModel.DataAnnotations;

namespace teste.Entidade
{
    public class Motorista
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string NumeroCNH { get; set; }
        public string CategoriaCNH { get; set; }
        public DateTime? DataNascimento { get; set; }
        public bool? Status { get; set; } // Ativo/Inativo
    }
}