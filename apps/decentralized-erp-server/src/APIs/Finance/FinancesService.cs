using DecentralizedErp.Infrastructure;

namespace DecentralizedErp.APIs;

public class FinancesService : FinancesServiceBase
{
    public FinancesService(DecentralizedErpDbContext context)
        : base(context) { }
}
