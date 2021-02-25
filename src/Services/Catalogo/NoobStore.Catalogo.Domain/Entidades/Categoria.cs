using NoobStore.Core.DomainObjects;

namespace NoobStore.Catalogo.Domain.Entidades
{
    public class Categoria : Entidade
    {
        public string Nome { get; private set; }
        public int Codigo { get; private set; }

        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;
        }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome,"O campo nao da categoria nao pode estar vazio");
            Validacoes.ValidarSeIgual(Codigo, 0,"O campo codigo nao pode ser 0");
        }
    }

}