using Microsoft.AspNetCore.Mvc;
using Stopalavras.Interfaces;
using Stopalavras.Models;

namespace Stopalavras.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class TemaController : ControllerBase {

        private readonly ITemaRepository _temaRepository;

        public TemaController(ITemaRepository temaRepository) {
            _temaRepository = temaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tema>>> ObterTemas() {
            try {
                var tema = await _temaRepository.ObterTemas();
                return Ok(tema);
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tema>> ObterTemaPorId(int id) {
            try {
                var tema = await _temaRepository.ObterTemaPorId(id);
                if (tema == null)
                    return NotFound("Tema não encontrado.");

                return Ok(tema);
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> InserirTema(Tema tema) {
            await _temaRepository.InserirTema(tema);
            return CreatedAtAction(nameof(ObterTemaPorId), new { id = tema.Id }, tema);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AtualizarTema(int id, Tema tema) {

            var temaExiste = await _temaRepository.ObterTemaPorId(id);
            if (temaExiste == null)
                return NotFound("Tema não encontrado.");

            await _temaRepository.AtualizarTema(tema);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirDeletarTema(int id) {
            await _temaRepository.DeletarTema(id);
            return NoContent();
        }
    }
}
