using Microsoft.AspNetCore.Mvc;

namespace DecentralizedErp.APIs;

[ApiController()]
public class FinancesController : FinancesControllerBase
{
    public FinancesController(IFinancesService service)
        : base(service) { }
}
