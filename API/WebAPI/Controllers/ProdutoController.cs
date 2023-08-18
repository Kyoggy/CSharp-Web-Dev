using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/produto")]
public class ProdutoController : ControllerBase
{
    //GET: api/produto/listar
    [HttpGet]
    [Route("listar")]
    public string Listar()
    {
        return "caramba!";
    }

    [HttpPost]
    [Route("cadastrar")]
    public Produto Cadastrar(Produto produto)
    {
        return produto;
    }
}
