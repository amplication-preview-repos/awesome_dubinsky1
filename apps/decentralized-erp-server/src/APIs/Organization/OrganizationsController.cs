using Microsoft.AspNetCore.Mvc;

namespace DecentralizedErp.APIs;

[ApiController()]
public class OrganizationsController : OrganizationsControllerBase
{
    public OrganizationsController(IOrganizationsService service)
        : base(service) { }
}
