using ReceitaCertaAPI.Domain.Interfaces;
using ReceitaCertaAPI.Domain.Models;
using ReceitaCertaAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReceitaCertaAPI.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoService(IProdutoRepository _produtoRepository)
        {
            this._produtoRepository = _produtoRepository ?? throw new ArgumentNullException(nameof(_produtoRepository));
        }
        public async Task Create(Produto entity)
        {
            await _produtoRepository.Create(entity);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> GetAll()
        {
            return _produtoRepository.GetAll();
        }

        public async Task<Produto> GetById(int id)
        {
            return await _produtoRepository.GetById(id);
        }

        public   IEnumerable<Produto> GetByName(string name)
        {
            return  _produtoRepository.GetByName(name);
        }

        public async Task Update(int id, Produto entity)
        {
            await _produtoRepository.Update(id, entity);
        }
    }
}
