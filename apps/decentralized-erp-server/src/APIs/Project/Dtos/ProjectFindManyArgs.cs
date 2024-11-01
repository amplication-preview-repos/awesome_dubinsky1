using DecentralizedErp.APIs.Common;
using DecentralizedErp.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace DecentralizedErp.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class ProjectFindManyArgs : FindManyInput<Project, ProjectWhereInput> { }
