using System;
using FluentValidation;
using NoobStore.Core.Messages;

namespace NoobStore.Vendas.Application.Commands
{
    public class AdicionarItemPedidoCommand : Command
    {
        public Guid ClienteId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public string Nome { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }

        public AdicionarItemPedidoCommand(Guid clienteId, Guid produtoId, string nome, int quantidade, decimal valorUnitario)
        {
            ClienteId = clienteId;
            ProdutoId = produtoId;
            Nome = nome;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }

        public override bool EhValid()
        {
            ValidationResult = new AdicionarItemPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AdicionarItemPedidoValidation : AbstractValidator<AdicionarItemPedidoCommand>
    {
        public AdicionarItemPedidoValidation()
        {
            RuleFor(c => c.ClienteId).NotEqual(Guid.Empty).WithMessage("Id do cliente é invalido");
            RuleFor(c => c.ProdutoId).NotEqual(Guid.Empty).WithMessage("Id do produto é invalido");
            RuleFor(c => c.Nome).NotEmpty().WithMessage("O nome do produto não foi informado");
            RuleFor(c => c.Quantidade).GreaterThan(0).WithMessage("A quantidade miníma de um item é 1");
            RuleFor(c => c.Quantidade).LessThan(0).WithMessage("A quantidade máxima de um item é 15");
            RuleFor(c => c.ValorUnitario).GreaterThan(0).WithMessage("O valor do item deve ser maior que 0");
        }
    }
}