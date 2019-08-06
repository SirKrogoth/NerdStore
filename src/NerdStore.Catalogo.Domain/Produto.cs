using NerdStore.Core.DomainObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace NerdStore.Catalogo.Domain
{
    //IAggregateRoot -- interface de marcação
    public class Produto : Entity, IAggregateRoot
    {
        public Guid categoriaId { get; private set; }
        public string nome { get; private set; }
        public string descricao { get; private set; }
        public bool ativo { get; private set; }
        public decimal valor { get; private set; }
        public DateTime dataCadastro { get; private set; }
        public string imagem { get; private set; }
        public int quantidadeEstoque { get; private set; }
        public Categoria categoria { get; private set; }

        public Produto(string nome, string descricao, bool ativo, decimal valor, Guid categoriaId, DateTime dataCadastro, string imagem)
        {
            this.categoriaId = categoriaId;
            this.nome = nome;
            this.descricao = descricao;
            this.ativo = ativo;
            this.valor = valor;
            this.dataCadastro = dataCadastro;
            this.imagem = imagem;
        }

        //AddRock Setter para alterar o valor da nossa propriedade
        public void Ativar() => ativo = true;
        public void Desativar() => ativo = false;

        public void AlterarCategoria(Categoria categoria)
        {
            this.categoria = categoria;
            categoriaId = categoria.id;
        }

        public void AlterarDescricao(string descricao)
        {
            this.descricao = descricao;
        }

        public void DebitarEstoque(int quantidadeEstoque)
        {
            if (quantidadeEstoque < 0) quantidadeEstoque *= -1;

            this.quantidadeEstoque -= quantidadeEstoque;
        }

        public void ReporEstoque(int quantidadeEstoque)
        {
            this.quantidadeEstoque += quantidadeEstoque;
        }

        public bool PossuiEstoque(int quantidadeEstoque)
        {
            return this.quantidadeEstoque >= quantidadeEstoque;
        }

        public void Validar()
        {

        }
    }
}
