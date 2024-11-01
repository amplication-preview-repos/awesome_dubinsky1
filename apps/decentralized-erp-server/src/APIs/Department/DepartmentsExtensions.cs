using DecentralizedErp.APIs.Dtos;
using DecentralizedErp.Infrastructure.Models;

namespace DecentralizedErp.APIs.Extensions;

public static class DepartmentsExtensions
{
    public static Department ToDto(this DepartmentDbModel model)
    {
        return new Department
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static DepartmentDbModel ToModel(
        this DepartmentUpdateInput updateDto,
        DepartmentWhereUniqueInput uniqueId
    )
    {
        var department = new DepartmentDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            department.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            department.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return department;
    }
}
