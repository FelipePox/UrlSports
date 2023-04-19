using Flunt.Validations;
using HelpURL.Domain.Core.ValueObjects;

namespace HelpURL.Domain.ValueObjects;

public sealed class URLTexto : ValueObject
{
    public URLTexto()
    {
        
    }

    public URLTexto(string texto)
    {
        Texto = texto;
        AddNotifications(new Contract<URLTexto>()
            .Requires()
            .IsUrl(Texto, "URL.Texto", "Url inválida.")
            );
    }

    public string Texto { get; private set; }
}
