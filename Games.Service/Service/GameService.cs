using Games.Domain.Entity;
using Games.Repository.Interface;
using Games.Service.Interface;
using Games.Service.Validation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Games.Service.Service
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _GameRepository;

        public GameService(IGameRepository GameRepository)
        {
            _GameRepository = GameRepository;
        }

        public async Task<List<Game>> Obter(int pagina, int quantidade)
        {
            return await _GameRepository.Obter(pagina, quantidade);
        }

        public async Task<Game> Obter(Guid id)
        {
            return await _GameRepository.Obter(id);
        }

        public async Task<Game> Inserir(Game game)
        {
            var existe = await _GameRepository.Existe(game.Nome, game.Fabricante);
            existe.IsNotTrue("Game já existe na base.");

            game.SetNewId(); 

            await _GameRepository.Inserir(game);

            return game;
        }

        public async Task Atualizar(Guid id, Game game)
        {
            var entidadeGame = await _GameRepository.Obter(id);
            entidadeGame.IsNotNull("Não é possivel atualizar, game não cadastrado");

            await _GameRepository.Atualizar(game);
        }

        public async Task Atualizar(Guid id, double preco)
        {
            var entidadeGame = await _GameRepository.Obter(id);
            entidadeGame.IsNotNull("Não é possivel atualizar, game não cadastrado");

            entidadeGame.SetPreco(preco);

            await _GameRepository.Atualizar(entidadeGame);
        }

        public async Task Remover(Guid id)
        {
            var entidadeGame = await _GameRepository.Obter(id);
            entidadeGame.IsNotNull("Não é possivel atualizar, game não cadastrado");

            await _GameRepository.Remover(id);
        }

        public void Dispose()
        {
            _GameRepository?.Dispose();
        }
    }
}