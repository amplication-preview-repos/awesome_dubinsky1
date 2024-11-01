using DecentralizedErp.Infrastructure;

namespace DecentralizedErp.APIs;

public class ProjectsService : ProjectsServiceBase
{
    public ProjectsService(DecentralizedErpDbContext context)
        : base(context) { }
}
