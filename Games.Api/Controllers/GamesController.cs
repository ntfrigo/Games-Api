using Games.Application.Interface;
using Games.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Games.Api.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGameApp _gameService;

        public GamesController(IGameApp gameService)
        {
            _gameService = gameService;
        }

        /// <summary>
        /// Buscar todos os games de forma paginada
        /// </summary>
        /// <remarks>
        /// Não é possível retornar os games sem paginação
        /// </remarks>
        /// <param name="pagina">Indica qual página está sendo consultada. Mínimo 1</param>
        /// <param name="quantidade">Indica a quantidade de reistros por página. Mínimo 1 e máximo 50</param>
        /// <response code="200">Retorna a lista de games</response>
        /// <response code="204">Caso não haja games</response>   
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            var games = await _gameService.Obter(pagina, quantidade);

            if (games.Count() == 0)
                return NoContent();

            return Ok(games);
        }

        /// <summary>
        /// Buscar um game pelo seu Id
        /// </summary>
        /// <param name="idgame">Id do game buscado</param>
        /// <response code="200">Retorna o game filtrado</response>
        /// <response code="204">Caso não haja game com este id</response>   
        [HttpGet("{idgame:guid}")]
        public async Task<ActionResult<GameViewModel>> Obter([FromRoute] Guid idgame)
        {
            var game = await _gameService.Obter(idgame);

            if (game == null)
                return NoContent();

            return Ok(game);
        }

        /// <summary>
        /// Inserir um game no catálogo
        /// </summary>
        /// <param name="gameInputModel">Dados do game a ser inserido</param>
        /// <response code="200">Cao o game seja inserido com sucesso</response>
        /// <response code="422">Caso já exista um game com mesmo nome para a mesma produtora</response>   
        [HttpPost]
        public async Task<ActionResult<GameViewModel>> Inserirgame([FromBody] GameInputViewModel gameInputModel)
        {
            try
            {
                var game = await _gameService.Inserir(gameInputModel);

                return Ok(game);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        /// <summary>
        /// Atualizar um game no catálogo
        /// </summary>
        /// /// <param name="idgame">Id do game a ser atualizado</param>
        /// <param name="gameInputModel">Novos dados para atualizar o game indicado</param>
        /// <response code="200">Cao o game seja atualizado com sucesso</response>
        /// <response code="404">Caso não exista um game com este Id</response>   
        [HttpPut("{idgame:guid}")]
        public async Task<ActionResult> Atualizargame([FromRoute] Guid idgame, [FromBody] GameInputViewModel gameInputModel)
        {
            try
            {
                await _gameService.Atualizar(idgame, gameInputModel);

                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Atualizar o preço de um game
        /// </summary>
        /// /// <param name="idgame">Id do game a ser atualizado</param>
        /// <param name="preco">Novo preço do game</param>
        /// <response code="200">Cao o preço seja atualizado com sucesso</response>
        /// <response code="404">Caso não exista um game com este Id</response>   
        [HttpPatch("{idgame:guid}/preco/{preco:double}")]
        public async Task<ActionResult> Atualizargame([FromRoute] Guid idgame, [FromRoute] double preco)
        {
            try
            {
                await _gameService.Atualizar(idgame, preco);

                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Excluir um game
        /// </summary>
        /// /// <param name="idgame">Id do game a ser excluído</param>
        /// <response code="200">Cao o preço seja atualizado com sucesso</response>
        /// <response code="404">Caso não exista um game com este Id</response>   
        [HttpDelete("{idgame:guid}")]
        public async Task<ActionResult> Apagargame([FromRoute] Guid idgame)
        {
            try
            {
                await _gameService.Remover(idgame);

                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}