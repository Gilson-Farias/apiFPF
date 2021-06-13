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
    public class ListarProdutoController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ListarProdutoController> _logger;
        public ListarProdutoController(ILogger<ListarProdutoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<produto>), 200)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            try
            {
                return Ok(new Business.produtoBusiness().GetAllProduto());
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
