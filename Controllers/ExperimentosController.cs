using LaboratorioManagerAPI.Dtos;
using LaboratorioManagerAPI.Services;
using LaboratorioManagerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaboratorioManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperimentosController : ControllerBase
    {
        private readonly IExperimentosService _experimentosService;

        public ExperimentosController(IExperimentosService experimentosService)
        {
            _experimentosService = experimentosService;
        }

        [HttpGet]
        public async Task<IActionResult> GetExperimentosActivosAsync()
        {
            var response = await _experimentosService.GetExperimentosActivosAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostExperimentoAsync(PostPutExperimentoDto experimentoDto)
        {
            var response = await _experimentosService.PostExperimentoAsync(experimentoDto);
            return Ok(response);
        }

        [HttpPut("{idExperimento}")]
        public async Task<IActionResult> PutExperimentoAsync([FromRoute]Guid idExperimento, [FromBody] PutExperimentoDto experimentoDto)
        {
            var response = await _experimentosService.PutExperimentoAsync(idExperimento, experimentoDto);
            return Ok(response);
        }

        [HttpDelete("{idExperimento}")]
        public async Task<IActionResult> DeleteExperimentoAsync(Guid idExperimento)
        {
            var response = await _experimentosService.DeleteExperimentoAsync(idExperimento);
            return Ok(response);
        }
    }
}
