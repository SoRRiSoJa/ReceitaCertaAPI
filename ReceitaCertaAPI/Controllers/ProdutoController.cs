using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace ReceitaCertaAPI.Controllers
{
    using ReceitaCertaAPI.Domain.Interfaces;
    using ReceitaCertaAPI.Domain.Models;
    using ReceitaCertaAPI.Domain.Repositories;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class ProdutoController:ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly IMarcaRepository _marcaRepository;
        public ProdutoController(IProdutoService _produtoService, IMarcaRepository _marcaRepository)
        {
            this._produtoService = _produtoService ?? throw new ArgumentNullException(nameof(_produtoService));
            this._marcaRepository = _marcaRepository ?? throw new ArgumentNullException(nameof(_marcaRepository));
        }
        [HttpPost]
        public async Task<ActionResult<Produto>> Salvar([FromBody] Produto produto)
        {
            await _produtoService.Create(produto);
            return Ok(produto);
        }
        [HttpPut]
        public async Task<ActionResult<Produto>> Editar([FromBody] Produto produto)
        {
            await _produtoService.Update(produto.ProdutoId,produto);
            return Ok(produto);
        }
        [HttpDelete("{idAgenda}")]
        public async Task<ActionResult<bool>> Excluir(int idProduto)
        {
            await _produtoService.Delete(idProduto);
            return Ok(true);
        }
       
        [HttpGet("nome/{nome}")]
        public ActionResult<IEnumerable<Produto>> ConsultarPorNome(string nome)
        {
            return Ok( _produtoService.GetByName(nome));
        }
        [HttpGet("marca")]
        public ActionResult<Marca> ConsultarMarcas()
        {
            var teste = _marcaRepository.GetById();
            return Ok(teste);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Listar()
        {
            return Ok(_produtoService.GetAll());
        }
    }
}
