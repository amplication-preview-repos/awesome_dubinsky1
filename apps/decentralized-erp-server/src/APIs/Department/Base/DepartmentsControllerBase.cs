using DecentralizedErp.APIs;
using DecentralizedErp.APIs.Common;
using DecentralizedErp.APIs.Dtos;
using DecentralizedErp.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace DecentralizedErp.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class DepartmentsControllerBase : ControllerBase
{
    protected readonly IDepartmentsService _service;

    public DepartmentsControllerBase(IDepartmentsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Department
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Department>> CreateDepartment(DepartmentCreateInput input)
    {
        var department = await _service.CreateDepartment(input);

        return CreatedAtAction(nameof(Department), new { id = department.Id }, department);
    }

    /// <summary>
    /// Delete one Department
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteDepartment(
        [FromRoute()] DepartmentWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteDepartment(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Departments
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Department>>> Departments(
        [FromQuery()] DepartmentFindManyArgs filter
    )
    {
        return Ok(await _service.Departments(filter));
    }

    /// <summary>
    /// Meta data about Department records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> DepartmentsMeta(
        [FromQuery()] DepartmentFindManyArgs filter
    )
    {
        return Ok(await _service.DepartmentsMeta(filter));
    }

    /// <summary>
    /// Get one Department
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Department>> Department(
        [FromRoute()] DepartmentWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Department(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Department
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateDepartment(
        [FromRoute()] DepartmentWhereUniqueInput uniqueId,
        [FromQuery()] DepartmentUpdateInput departmentUpdateDto
    )
    {
        try
        {
            await _service.UpdateDepartment(uniqueId, departmentUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
