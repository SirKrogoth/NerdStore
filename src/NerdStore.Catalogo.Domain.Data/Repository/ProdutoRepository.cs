﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NerdStore.Catalogo.Domain;
using NerdStore.Core.Data;

namespace NerdStore.Catalogo.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly CatalogoContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public ProdutoRepository(CatalogoContext context)
        {
            _context = context;
        }

        public IUnitOfWork unitOfWork => throw new NotImplementedException();

        //AsNoTracking serve para diminuir um pouco o uso do EntityFrameWorkCore.
        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            return await _context.Produtos.AsNoTracking().ToListAsync();
        }

        public async Task<Produto> ObterPorID(Guid produtoId)
        {
            return await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.id == produtoId);
        }

        public async Task<IEnumerable<Produto>> ObterPorCategoria(int codigo)
        {
            return await _context.Produtos.AsNoTracking().Include(p => p.categoria).Where(c => c.categoria.codigo== codigo).ToListAsync();
        }

        public async Task<IEnumerable<Categoria>> ObterCategorias()
        {
            return await _context.Categorias.AsNoTracking().ToListAsync();
        }

        public void Adicionar(Produto produto)
        {
            _context.Produtos.Add(produto);
        }

        public void Atualizar(Produto produto)
        {
            _context.Produtos.Update(produto);
        }

        public void Adicionar(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
        }

        public void Atualizar(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}