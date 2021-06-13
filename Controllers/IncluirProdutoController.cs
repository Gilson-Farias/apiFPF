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
    public class IncluirProdutoController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<IncluirProdutoController> _logger;
        public IncluirProdutoController(ILogger<IncluirProdutoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<produto>), 200)]
        [ProducesResponseType(500)]
        public IActionResult Get(int codigo, string nome, decimal quantidade, decimal valor)
        {
            var produto = new produto();

            produto.codigo = codigo;
            produto.nome = nome;
            produto.quantidade = quantidade;
            produto.valorUnitario = valor;

            try
            {
                return Ok(new Business.produtoBusiness().GetAllIncluirProd(produto));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
