using LaboratorioManagerAPI.Dtos;
using LaboratorioManagerAPI.Services;
using LaboratorioManagerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaboratorioManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CientificosXExperiementosController : ControllerBase
    {
        private readonly ICientificosXExperimentosService _cientificosXExperimentosService;

        public CientificosXExperiementosController(ICientificosXExperimentosService cientificosXExperimentosService)
        {
            _cientificosXExperimentosService = cientificosXExperimentosService;
        }

        [HttpPost]
        public async Task<IActionResult> PostCientificoXExperimentoAsync([FromBody] PostCientificosXexperimentoDto postCientificosXexperimentoDto)
        {
           var response = await _cientificosXExperimentosService.PostCientificoXExperimentoAsync(postCientificosXexperimentoDto);
            return Ok(response);
        }
    }
}
