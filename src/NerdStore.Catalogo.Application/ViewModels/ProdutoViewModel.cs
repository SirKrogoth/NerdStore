using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NerdStore.Catalogo.Application.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public Guid id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid categoriaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool ativo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal valor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime dataCadastro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string imagem { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} precisa ter o valor mínimo de {1}")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int quantidadeEstoque { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} precisa ter o valor mínimo de {1}")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int altura { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} precisa ter o valor mínimo de {1}")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int largura { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} precisa ter o valor mínimo de {1}")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int profundidade { get; set; }

        public IEnumerable<CategoriaViewModel> categorias { get; set; }
    }
}