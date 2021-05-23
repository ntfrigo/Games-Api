using Games.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Games.Service.Interface
{
    public interface IGameService : IDisposable
    {
        Task<List<Game>> Obter(int pagina, int quantidade);
        Task<Game> Obter(Guid id);
        Task<Game> Inserir(Game Game);
        Task Atualizar(Guid id, Game Game);
        Task Atualizar(Guid id, double preco);
        Task Remover(Guid id);
    }
}
