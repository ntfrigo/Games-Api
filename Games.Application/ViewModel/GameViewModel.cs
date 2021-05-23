using System;

namespace Games.Application.ViewModel
{
    public class GameViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Fabricante { get; set; }
        public double Preco { get; set; }
        public int Nota { get; set; }

        public string Descricao { get; set; }
    }
}
