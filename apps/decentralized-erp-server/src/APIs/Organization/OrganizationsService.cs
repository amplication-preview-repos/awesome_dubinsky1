using DecentralizedErp.Infrastructure;

namespace DecentralizedErp.APIs;

public class OrganizationsService : OrganizationsServiceBase
{
    public OrganizationsService(DecentralizedErpDbContext context)
        : base(context) { }
}
