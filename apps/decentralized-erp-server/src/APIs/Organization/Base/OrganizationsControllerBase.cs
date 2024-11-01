using DecentralizedErp.APIs;
using DecentralizedErp.APIs.Common;
using DecentralizedErp.APIs.Dtos;
using DecentralizedErp.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace DecentralizedErp.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class OrganizationsControllerBase : ControllerBase
{
    protected readonly IOrganizationsService _service;

    public OrganizationsControllerBase(IOrganizationsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Organization
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Organization>> CreateOrganization(OrganizationCreateInput input)
    {
        var organization = await _service.CreateOrganization(input);

        return CreatedAtAction(nameof(Organization), new { id = organization.Id }, organization);
    }

    /// <summary>
    /// Delete one Organization
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteOrganization(
        [FromRoute()] OrganizationWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteOrganization(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Organizations
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Organization>>> Organizations(
        [FromQuery()] OrganizationFindManyArgs filter
    )
    {
        return Ok(await _service.Organizations(filter));
    }

    /// <summary>
    /// Meta data about Organization records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> OrganizationsMeta(
        [FromQuery()] OrganizationFindManyArgs filter
    )
    {
        return Ok(await _service.OrganizationsMeta(filter));
    }

    /// <summary>
    /// Get one Organization
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Organization>> Organization(
        [FromRoute()] OrganizationWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Organization(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Organization
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateOrganization(
        [FromRoute()] OrganizationWhereUniqueInput uniqueId,
        [FromQuery()] OrganizationUpdateInput organizationUpdateDto
    )
    {
        try
        {
            await _service.UpdateOrganization(uniqueId, organizationUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
