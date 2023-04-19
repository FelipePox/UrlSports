using HelpURL.Domain.Core.Entities;
using HelpURL.Domain.ValueObjects;

namespace HelpURL.Domain.Entities;

public sealed class URL : Entity
{
    public URL()
    {
        
    }
    public URL(URLTexto urlTexto, Descricao descricao) : base()
    {
        URLTexto = urlTexto;
        Descricao = descricao;

        AddNotifications(URLTexto, Descricao);
    }
    public URLTexto URLTexto { get; private set; }
    public Descricao Descricao { get; private set; }


    public void Update(URLTexto urlTexto, Descricao descricao)
    {
        URLTexto = urlTexto;
        Descricao = descricao;
        AddNotifications(URLTexto, Descricao);

        if (IsValid)
            AtualizadoEm = DateTime.Now.ToLocalTime();
    }
}
