using System;
using System.ComponentModel.DataAnnotations;

namespace NoobStore.Catalogo.Application.ViewModels
{
    public class CategoriaViewModel
    {
        [Key] public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Campo {o} e obrigatório")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Campo {o} e obrigatório")]
        public int Codigo { get; set; }
    }
}