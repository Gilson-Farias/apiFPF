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
    public class EditarProdutoController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<EditarProdutoController> _logger;
        public EditarProdutoController(ILogger<EditarProdutoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<produto>), 200)]
        [ProducesResponseType(500)]
        public IActionResult Get(int codigo, string nome, decimal quantidade, decimal valor)
        {
            var prod = new produto();

            prod.codigo = codigo;
            prod.nome = nome;
            prod.quantidade = quantidade;
            prod.valorUnitario = valor;
            
            try
            {
                return Ok(new Business.produtoBusiness().GetAllEditarProd(prod));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
