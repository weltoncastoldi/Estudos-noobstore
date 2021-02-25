using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoobStore.Core.DomainObjects;

namespace NoobStore.Catalogo.Domain.ObjetosValor
{
    public class Dimensoes
    {
        public decimal Altura { get; private set; }
        public decimal Largura { get; private set; }
        public decimal Profundidade { get; private set; }

        public Dimensoes(decimal altura, decimal largura, decimal profundidade)
        {
            Validacoes.ValidarSeMenorIgualMinimo(altura, 1, "O campo altura nao pode ser menor que 0");
            Validacoes.ValidarSeMenorIgualMinimo(largura, 1, "O campo altura nao pode ser menor que 0");
            Validacoes.ValidarSeMenorIgualMinimo(profundidade, 1, "O campo altura nao pode ser menor que 0");
            Altura = altura;
            Largura = largura;
            Profundidade = profundidade;
        }

        public string DescricaoFormatada()
        {
            return $"LxAxP: {Largura} x {Altura} x {Profundidade}";
        }

        public override string ToString()
        {
            return DescricaoFormatada();
        }
    }
}
