using System.Collections.Generic;
using System.Threading.Tasks;
using BiblicalArchitecture.Domain.Entidades.Solid;
using BiblicalArchitecture.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BiblicalArchitecture.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolidController : ControllerBase
    {
        private readonly ILogger<SolidController> _logger;
        private readonly ISolidService _solidService;

        public SolidController(ILogger<SolidController> logger, ISolidService solidService)
        {
            _logger = logger;
            _solidService = solidService;
        }

        /// <summary>
        /// Obtém todos os princípios SOLID
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PrincipioSolid>>> ObterTodos()
        {
            _logger.LogInformation("Obtendo todos os princípios SOLID");
            var principios = await _solidService.ObterTodosPrincipiosAsync();
            return Ok(principios);
        }

        /// <summary>
        /// Obtém um princípio SOLID pelo ID
        /// </summary>
        /// <param name="id">ID do princípio (1 a 5)</param>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PrincipioSolid>> ObterPorId(int id)
        {
            _logger.LogInformation($"Obtendo princípio SOLID com ID: {id}");
            var principio = await _solidService.ObterPrincipioPorIdAsync(id);
            
            if (principio == null)
            {
                _logger.LogWarning($"Princípio com ID {id} não encontrado");
                return NotFound($"Nenhum princípio encontrado com o ID {id}");
            }

            return Ok(principio);
        }

        /// <summary>
        /// Obtém um princípio SOLID pela sigla (S, O, L, I, D)
        /// </summary>
        /// <param name="sigla">Sigla do princípio (S, O, L, I, D)</param>
        [HttpGet("{sigla}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PrincipioSolid>> ObterPorSigla(string sigla)
        {
            _logger.LogInformation($"Obtendo princípio SOLID com a sigla: {sigla}");
            var principio = await _solidService.ObterPrincipioPorSiglaAsync(sigla);
            
            if (principio == null)
            {
                _logger.LogWarning($"Princípio com a sigla {sigla} não encontrado");
                return NotFound($"Nenhum princípio encontrado com a sigla {sigla}");
            }

            return Ok(principio);
        }
    }
}
