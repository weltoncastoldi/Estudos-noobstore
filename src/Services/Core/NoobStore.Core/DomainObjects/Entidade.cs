using System;

namespace NoobStore.Core.DomainObjects
{
    public abstract class Entidade
    {
        public Guid Id { get; }

        protected Entidade()
        {
            Id = new Guid();
        }

        public override string ToString()
        {
            //Sempre que usar um ToString vamos ver o nome da Entidade + seu codigo
            return $"{GetType().Name} [Id= {Id}]";
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entidade;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(this, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public override int GetHashCode()
        {
            //Protege aplicacao para sempre ter um hashCode diferente
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public static bool operator ==(Entidade a, Entidade b)
        {
            if(ReferenceEquals(a, null) && ReferenceEquals(b, null)) return true;
            
            if(ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entidade a, Entidade b)
        {
            return !(a == b);
        }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}