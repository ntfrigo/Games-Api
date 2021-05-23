using System;

namespace Games.Domain.Entity
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Fabricante { get; set; }
        public double Preco { get; set; }
        public int Nota { get; set; }

        public void SetNewId()
        {
            Id = Guid.NewGuid();
        }

        public void SetPreco(double preco)
        {
            Preco = preco;
        }
    }
}
