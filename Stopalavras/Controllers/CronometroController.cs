using Microsoft.AspNetCore.Mvc;
using Stopalavras.Interfaces;
using Stopalavras.Models;

namespace Stopalavras.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class CronometroController : ControllerBase {

        private readonly ICronometroRepository _cronometroRepository;

        public CronometroController(ICronometroRepository cronometroRepository) {
            _cronometroRepository = cronometroRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cronometro>>> ObterCronometro() {
            try {
                var cronometro = await _cronometroRepository.ObterCronometro();
                return Ok(cronometro);
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarCronometro(Cronometro cronometro) {
            await _cronometroRepository.AtualizarCronometro(cronometro);
            return NoContent();
        }
    }
}
