using Microsoft.AspNetCore.Mvc;

namespace DecentralizedErp.APIs;

[ApiController()]
public class DepartmentsController : DepartmentsControllerBase
{
    public DepartmentsController(IDepartmentsService service)
        : base(service) { }
}
