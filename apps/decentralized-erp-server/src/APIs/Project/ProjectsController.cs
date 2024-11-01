using Microsoft.AspNetCore.Mvc;

namespace DecentralizedErp.APIs;

[ApiController()]
public class ProjectsController : ProjectsControllerBase
{
    public ProjectsController(IProjectsService service)
        : base(service) { }
}
