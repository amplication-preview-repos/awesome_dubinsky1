using DecentralizedErp.Infrastructure;

namespace DecentralizedErp.APIs;

public class DepartmentsService : DepartmentsServiceBase
{
    public DepartmentsService(DecentralizedErpDbContext context)
        : base(context) { }
}
