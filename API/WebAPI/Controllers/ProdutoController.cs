using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using System;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/produto")]
    public class ProdutoController : ControllerBase
    {
        private static List<Produto> produtos = new List<Produto>();

        [HttpGet("listar")]
        public IActionResult Listar() => produtos.Count == 0 ? NotFound() : Ok(produtos);

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromBody] Produto produto)
        {
            produtos.Add(produto);
            return Created("api/produto/cadastrar", produto);
        }

        [HttpGet("buscar/{nome}")]
        public IActionResult Buscar([FromRoute] string nome)
        {
            //Forma de verificar através de um For Each
            /* foreach (var item in produtos)
            {
                if(item.Nome == nome)
                {
                    return Ok(item);
                }
            }
            return NotFound(); */

            //Sugestão do ChatGPT
            var resultados = produtos.FindAll(p => p.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase));
            return Ok(resultados);
        }
    }
}
