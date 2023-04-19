using HelpURL.Domain.Entities;
using HelpURL.Domain.Interfaces;
using HelpURL.Infra.Data.Context;
using HelpURL.Infra.Data.Repositories.Core;

namespace HelpURL.Infra.Data.Repositories
{
    public sealed class URLRepository : BaseRepository<URL> , IURLRepository
    {
        public URLRepository(HelpURLContext context) : base(context)
        { }
    }
}
