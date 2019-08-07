using System.Security.Cryptography;
using System.Security.Principal;
using NerdStore.Core.DomainObject;

namespace NerdStore.Catalogo.Domain
{
    public class Dimensoes
    {
        public decimal altura { get; private set; }
        public decimal largura { get; private set; }
        public decimal profundidade { get; private set; }

        public Dimensoes(decimal altura, decimal largura, decimal profundidade)
        {
            Validacoes.ValidarSeMenorQue(altura, 1, "O campo Altura não pode ser menor ou igual a 0");
            Validacoes.ValidarSeMenorQue(largura, 1, "A largura informada é menor que o mínimo de 1.");
            Validacoes.ValidarSeMenorQue(profundidade, 1, "A profundidade informada é menor que o mínimo de 1.");

            this.altura = altura;
            this.largura = largura;
            this.profundidade = profundidade;
        }

        public string DescricaoFormatada()
        {
            return $"LxAxP: {largura} x {altura} x {profundidade}";
        }

        public override string ToString()
        {
            return DescricaoFormatada();
        }
    }
}