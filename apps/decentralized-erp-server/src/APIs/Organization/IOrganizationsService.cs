using DecentralizedErp.APIs.Common;
using DecentralizedErp.APIs.Dtos;

namespace DecentralizedErp.APIs;

public interface IOrganizationsService
{
    /// <summary>
    /// Create one Organization
    /// </summary>
    public Task<Organization> CreateOrganization(OrganizationCreateInput organization);

    /// <summary>
    /// Delete one Organization
    /// </summary>
    public Task DeleteOrganization(OrganizationWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Organizations
    /// </summary>
    public Task<List<Organization>> Organizations(OrganizationFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Organization records
    /// </summary>
    public Task<MetadataDto> OrganizationsMeta(OrganizationFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Organization
    /// </summary>
    public Task<Organization> Organization(OrganizationWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Organization
    /// </summary>
    public Task UpdateOrganization(
        OrganizationWhereUniqueInput uniqueId,
        OrganizationUpdateInput updateDto
    );
}
