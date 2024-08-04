using LaboratorioManagerAPI.Dtos;
using LaboratorioManagerAPI.Services;
using LaboratorioManagerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaboratorioManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CientificosController : ControllerBase
    {
        private readonly ICientificosService _cientificosService;

        public CientificosController(ICientificosService cientificosService)
        {
            _cientificosService = cientificosService;
        }

        [HttpPost]
        public async Task<IActionResult> PostCientificoAsync(CientificoPostDto cientificoDto)
        {
            var response = await _cientificosService.PostCientificoAsync(cientificoDto);
            return Ok(response);
        }

        [HttpGet("{idExperimento}")]
        public async Task<IActionResult> GetCientificosAfueraDeExperimento([FromRoute]Guid idExperimento)
        {
            var response = await _cientificosService.GetCientificosAfueraDeExperimento(idExperimento);
            return Ok(response);
        }

        [HttpPut("{idCientifico}")]
        public async Task<IActionResult> PutCientificoAsync([FromRoute]Guid idCientifico, CientificoPutDto cientificoDto)
        {
            var response = await _cientificosService.PutCientificoAsync(idCientifico, cientificoDto);
            return Ok(response);
        }

        [HttpDelete("{idCientifico}")]
        public async Task<IActionResult> DeleteCientificoAsync(Guid idCientifico)
        {
            var response = await _cientificosService.DeleteCientificoAsync(idCientifico);
            return Ok(response);
        }
    }
}
