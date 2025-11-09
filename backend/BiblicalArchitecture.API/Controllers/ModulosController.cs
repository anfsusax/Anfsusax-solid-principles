using System.Collections.Generic;
using System.Threading.Tasks;
using BiblicalArchitecture.Domain.Entidades;
using BiblicalArchitecture.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BiblicalArchitecture.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModulosController : ControllerBase
    {
        private readonly IModuloService _moduloService;

        public ModulosController(IModuloService moduloService)
        {
            _moduloService = moduloService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modulo>>> ObterTodos()
        {
            var modulos = await _moduloService.ObterTodosModulosAsync();
            return Ok(modulos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Modulo>> ObterPorId(int id)
        {
            var modulo = await _moduloService.ObterModuloPorIdAsync(id);
            
            if (modulo == null)
                return NotFound();
                
            return Ok(modulo);
        }
    }
}
