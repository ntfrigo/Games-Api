using Games.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Games.Application.Interface
{
    public interface IGameApp : IDisposable
    {
        Task<List<GameViewModel>> Obter(int pagina, int quantidade);
        Task<GameViewModel> Obter(Guid id);
        Task<GameViewModel> Inserir(GameInputViewModel Game);
        Task Atualizar(Guid id, GameInputViewModel Game);
        Task Atualizar(Guid id, double preco);
        Task Remover(Guid id);
    }
}
