using NerdStore.Core.DomainObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace NerdStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        public string nome { get; private set; }
        public int codigo { get; private set; }
        public ICollection<Produto> produtos;

        protected Categoria() { }

        public Categoria(string nome, int codigo)
        {
            this.nome = nome;
            this.codigo = codigo;

            Validar();
        }

        public override string ToString()
        {
            return $"{nome} - {codigo}";
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(nome, "O campo Nome do Produto não pode estar vazio.");
            Validacoes.ValidarSeIgual(codigo, 0,"O campo Código do Produto não pode ser zero.");
        }
    }
}
