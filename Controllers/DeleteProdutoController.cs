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
    public class DeleteProdutoController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<DeleteProdutoController> _logger;
        public DeleteProdutoController(ILogger<DeleteProdutoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<produto>), 200)]
        [ProducesResponseType(500)]
        public IActionResult Get( int codigo )
        {
            try
            {
                return Ok(new Business.produtoBusiness().GetAllDeleteProd( codigo ));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
