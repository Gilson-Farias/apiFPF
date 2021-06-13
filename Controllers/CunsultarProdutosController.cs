using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace apiFPF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsultarProdutoController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ConsultarProdutoController> _logger;
        public ConsultarProdutoController(ILogger<ConsultarProdutoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<produto>), 200)]
        [ProducesResponseType(500)]
        public IActionResult Get(int codigo)
        {
            try
            {
                return Ok(new Business.produtoBusiness().GetAllConsultaProd(codigo));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
