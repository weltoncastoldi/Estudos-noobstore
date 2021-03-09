using NoobStore.Core.DomainObjects;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NoobStore.Vendas.Domain
{
    public class Voucher : Entidade
    {
        public string Codigo { get; private set; }
        public decimal? Percentual { get; private set; }
        public decimal?  ValorDesconto { get; private set; }
        public int Quantidade { get; private set; }
        public TipoDescontoVoucher TipoDescontoVoucher { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataAtualizacao { get; private set; }
        public DateTime DataValidade { get; private set; }
        public bool Ativo { get; private set; }
        public bool Utilizado { get; private set; }

        //Para EF
        public ICollection<Pedido> Pedidos { get; set; }
    }
}