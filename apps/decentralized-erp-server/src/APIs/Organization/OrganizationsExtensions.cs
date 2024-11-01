using DecentralizedErp.APIs.Dtos;
using DecentralizedErp.Infrastructure.Models;

namespace DecentralizedErp.APIs.Extensions;

public static class OrganizationsExtensions
{
    public static Organization ToDto(this OrganizationDbModel model)
    {
        return new Organization
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static OrganizationDbModel ToModel(
        this OrganizationUpdateInput updateDto,
        OrganizationWhereUniqueInput uniqueId
    )
    {
        var organization = new OrganizationDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            organization.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            organization.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return organization;
    }
}
