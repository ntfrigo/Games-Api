using Games.Domain.Entity;
using Games.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Games.Repository.Service
{
    public class GameRepository : IGameRepository
    {
        private static Dictionary<Guid, Game> jogos = new Dictionary<Guid, Game>()
        {
            {Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), new Game{ Id = Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), Nome = "Fifa 21", Fabricante = "EA", Preco = 200} },
            {Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), new Game{ Id = Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), Nome = "Fifa 20", Fabricante = "EA", Preco = 190} },
            {Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"), new Game{ Id = Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"), Nome = "Fifa 19", Fabricante = "EA", Preco = 180} },
            {Guid.Parse("da033439-f352-4539-879f-515759312d53"), new Game{ Id = Guid.Parse("da033439-f352-4539-879f-515759312d53"), Nome = "Fifa 18", Fabricante = "EA", Preco = 170} },
            {Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"), new Game{ Id = Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"), Nome = "Street Fighter V", Fabricante = "Capcom", Preco = 80} },
            {Guid.Parse("c3c9b5da-6a45-4de1-b28b-491cbf83b589"), new Game{ Id = Guid.Parse("c3c9b5da-6a45-4de1-b28b-491cbf83b589"), Nome = "Grand Theft Auto V", Fabricante = "Rockstar", Preco = 190} }
        };

        public Task<List<Game>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Game> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
                return Task.FromResult<Game>(null);

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Game>> Obter(string nome, string fabricante)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Fabricante.Equals(fabricante)).ToList());
        }

        public Task<List<Game>> ObterSemLambda(string nome, string fabricante)
        {
            var retorno = jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Fabricante.Equals(fabricante)).ToList();
            return Task.FromResult(retorno);
        }

        public Task Inserir(Game jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task Atualizar(Game jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

        public Task<bool> Existe(string nome, string fabricante)
        {
            var retorno = jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Fabricante.Equals(fabricante)).Any();
            return Task.FromResult(retorno);
        }
    }
}
