namespace teste.Entidade
{
    public class PostoExemplo
    {
        public PostoExemplo()
        {
            list = new List<ValoresBomba>
            {
                new ValoresBomba() { TipoCombustivel = "Gasolina" , preco = 4.29M},
                new ValoresBomba() { TipoCombustivel = "Etanol" , preco =  2.99M},
                new ValoresBomba() { TipoCombustivel = "Diesel" , preco =  2.09M}
            };
        }

        public List<ValoresBomba> list { get; set; }
    }

    public class ValoresBomba
    {
        public string TipoCombustivel {  get; set; }
        public decimal preco { get; set; }
    }
}
