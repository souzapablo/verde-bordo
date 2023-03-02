using VerdeBordo.Core.Entities;
using VerdeBordo.Core.Repositories;
using VerdeBordo.Infrastructure.Persistence.Repositories.Shared;

namespace VerdeBordo.Infrastructure.Persistence.Repositories;

public class EmbroideryRepository : BaseRepository<Embroidery>, IEmbroideryRepository 
{
    public EmbroideryRepository(VerdeBordoDbContext context) : base(context) { }
}