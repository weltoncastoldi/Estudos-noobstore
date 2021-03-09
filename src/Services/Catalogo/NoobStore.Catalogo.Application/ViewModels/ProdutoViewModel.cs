using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NoobStore.Catalogo.Application.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public Guid Guid { get; set; }
        
        [Required(ErrorMessage = "Campo {o} e obrigatório")]
        public Guid CategoriaId { get; set; }
   
        [Required(ErrorMessage = "Campo {o} e obrigatório")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Campo {o} e obrigatório")]
        public string Descricao { get; set; }
        
        [Required(ErrorMessage = "Campo {o} e obrigatório")]
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "Campo {o} e obrigatório")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Campo {o} e obrigatório")]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "Campo {o} e obrigatório")]
        public string Imagem { get; set; }

        [Range(1,int.MaxValue, ErrorMessage = "Campo {o} precisa ter o valor minimo de {1}")]
        [Required(ErrorMessage = "Campo {o} e obrigatório")]
        public int QuantidadeEstoque { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Campo {o} precisa ter o valor minimo de {1}")]
        [Required(ErrorMessage = "Campo {o} e obrigatório")]
        public int Altura { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Campo {o} precisa ter o valor minimo de {1}")]
        [Required(ErrorMessage = "Campo {o} e obrigatório")]
        public int Largura { get; set; }

        [Range(1,int.MaxValue, ErrorMessage = "Campo {o} precisa ter o valor minimo de {1}")]
        [Required(ErrorMessage = "Campo {o} e obrigatório")]
        public int Profundidade { get; set; }
        
        public IEnumerable<CategoriaViewModel> Categorias { get; set; }
    }
}