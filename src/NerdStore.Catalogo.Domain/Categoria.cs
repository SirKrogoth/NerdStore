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

        public Categoria(string nome, int codigo)
        {
            this.nome = nome;
            this.codigo = codigo;   
        }

        public override string ToString()
        {
            return $"{nome} - {codigo}";
        }
    }
}
