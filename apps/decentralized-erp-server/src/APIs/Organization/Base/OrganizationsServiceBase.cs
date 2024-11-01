using DecentralizedErp.APIs;
using DecentralizedErp.APIs.Common;
using DecentralizedErp.APIs.Dtos;
using DecentralizedErp.APIs.Errors;
using DecentralizedErp.APIs.Extensions;
using DecentralizedErp.Infrastructure;
using DecentralizedErp.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DecentralizedErp.APIs;

public abstract class OrganizationsServiceBase : IOrganizationsService
{
    protected readonly DecentralizedErpDbContext _context;

    public OrganizationsServiceBase(DecentralizedErpDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Organization
    /// </summary>
    public async Task<Organization> CreateOrganization(OrganizationCreateInput createDto)
    {
        var organization = new OrganizationDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            organization.Id = createDto.Id;
        }

        _context.Organizations.Add(organization);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<OrganizationDbModel>(organization.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Organization
    /// </summary>
    public async Task DeleteOrganization(OrganizationWhereUniqueInput uniqueId)
    {
        var organization = await _context.Organizations.FindAsync(uniqueId.Id);
        if (organization == null)
        {
            throw new NotFoundException();
        }

        _context.Organizations.Remove(organization);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Organizations
    /// </summary>
    public async Task<List<Organization>> Organizations(OrganizationFindManyArgs findManyArgs)
    {
        var organizations = await _context
            .Organizations.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return organizations.ConvertAll(organization => organization.ToDto());
    }

    /// <summary>
    /// Meta data about Organization records
    /// </summary>
    public async Task<MetadataDto> OrganizationsMeta(OrganizationFindManyArgs findManyArgs)
    {
        var count = await _context.Organizations.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Organization
    /// </summary>
    public async Task<Organization> Organization(OrganizationWhereUniqueInput uniqueId)
    {
        var organizations = await this.Organizations(
            new OrganizationFindManyArgs { Where = new OrganizationWhereInput { Id = uniqueId.Id } }
        );
        var organization = organizations.FirstOrDefault();
        if (organization == null)
        {
            throw new NotFoundException();
        }

        return organization;
    }

    /// <summary>
    /// Update one Organization
    /// </summary>
    public async Task UpdateOrganization(
        OrganizationWhereUniqueInput uniqueId,
        OrganizationUpdateInput updateDto
    )
    {
        var organization = updateDto.ToModel(uniqueId);

        _context.Entry(organization).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Organizations.Any(e => e.Id == organization.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
