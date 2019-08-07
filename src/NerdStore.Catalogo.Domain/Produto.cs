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
        public Dimensoes dimensoes { get; private set; }

        public Produto(string nome, string descricao, bool ativo, decimal valor, Guid categoriaId, DateTime dataCadastro, string imagem, Dimensoes dimensoes)
        {
            this.categoriaId = categoriaId;
            this.nome = nome;
            this.descricao = descricao;
            this.ativo = ativo;
            this.valor = valor;
            this.dataCadastro = dataCadastro;
            this.imagem = imagem;
            this.dimensoes = dimensoes;

            Validar();
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
            Validacoes.ValidarSeVazio(descricao, "O campo Descrição do produto não poderá estar vazio.");
            this.descricao = descricao;
        }

        public void DebitarEstoque(int quantidade)
        {
            if (quantidade < 0) quantidade *= -1;
            if(!PossuiEstoque(quantidade)) throw new DomainException("Estoque insuficiente.");
            this.quantidadeEstoque -= quantidade;
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
            Validacoes.ValidarSeVazio(nome, "O campo Nome do produto não pode estar vazio");
            Validacoes.ValidarSeVazio(descricao, "O campo Descricao do produto não pode estar vazio");
            Validacoes.ValidarSeVazio(imagem, "O campo Imagem do produto não pode estar vazio");
            //Validacoes.ValidarSeDiferente(categoriaId, Guid.Empty, "O campo CategoriaId do produto não pode estar vazio");
            Validacoes.ValidarSeMenorQue(valor, 1, "O campo Valor do produto não pode se menor igual a 0");
            Validacoes.ValidarSeNulo(nome, "O campo Nome não pode ser null.");
        }
    }
}
