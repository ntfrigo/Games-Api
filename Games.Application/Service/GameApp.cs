using AutoMapper;
using Games.Application.Interface;
using Games.Application.ViewModel;
using Games.Domain.Entity;
using Games.Service.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Games.Application.Service
{
    public class GameApp : IGameApp
    {
        private readonly IMapper _mapper;
        private readonly IGameService _gameService;

        public GameApp(IGameService gameService, IMapper mapper)
        {
            _gameService = gameService;
            _mapper = mapper;
        }

        public async Task<List<GameViewModel>> Obter(int pagina, int quantidade)
        {
            var obj = await _gameService.Obter(pagina, quantidade);
            return _mapper.Map<List<GameViewModel>>(obj);            
        }

        public async Task<GameViewModel> Obter(Guid id)
        {
            var obj = await _gameService.Obter(id);
            return _mapper.Map<GameViewModel> (obj);
        }

        public async Task<GameViewModel> Inserir(GameInputViewModel game)
        {
            var obj = _mapper.Map<Game>(game);

            var resp = await _gameService.Inserir(obj);

            return _mapper.Map<GameViewModel>(resp);

        }

        public async Task Atualizar(Guid id, GameInputViewModel game)
        {
            var obj = _mapper.Map<Game>(game);

            await _gameService.Atualizar(id, obj);
        }

        public async Task Atualizar(Guid id, double preco)
        {
            await _gameService.Atualizar(id, preco);
        }

        public async Task Remover(Guid id)
        {
            //Begin();
            await _gameService.Remover(id);
            //Commit();
        }

        public void Dispose()
        {
            _gameService?.Dispose();
        }
    }
}
