using Flunt.Notifications;

namespace HelpURL.Domain.Core.Entities;

public abstract class Entity  : Notifiable<Notification>
{
    public Entity()
    {
        Id = Guid.NewGuid();
        CriadoEm = DateTime.Now.ToLocalTime();
        AtualizadoEm = DateTime.Now.ToLocalTime();
    }

    public Guid Id { get; protected set; }
    public DateTime CriadoEm { get; protected set; }
    public DateTime AtualizadoEm { get; protected set; }
}
