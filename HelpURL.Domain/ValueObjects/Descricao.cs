using Flunt.Validations;
using HelpURL.Domain.Core.ValueObjects;

namespace HelpURL.Domain.ValueObjects
{
    public sealed class Descricao : ValueObject
    {
        public Descricao()
        {
            
        }
        public Descricao(string texto)
        {
            Texto = texto;
            AddNotifications(new Contract<Descricao>()
           .Requires()
           .IsNotNullOrWhiteSpace(Texto, "Descricao.Texto", "A descrição não pode ser vazia")
           .IsGreaterOrEqualsThan(Texto.Length, 5, "Descricao.Texto", "A descrição não pode conter menos de 5 caracteres.")
           .IsLowerOrEqualsThan(Texto.Length, 255, "Descricao.Texto", "A descrição não pode conter mais de 255 caracteres.")
           );
        }
        public string Texto { get; private set; }
    }
}
