using Games.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Games.Repository.Interface
{
    public interface IGameRepository : IDisposable
    {
        Task<List<Game>> Obter(int pagina, int quantidade);
        Task<Game> Obter(Guid id);
        Task<List<Game>> Obter(string nome, string produtora);
        Task Inserir(Game jogo);
        Task Atualizar(Game jogo);
        Task Remover(Guid id);
        Task<bool> Existe(string nome, string fabricante);
    }
}
