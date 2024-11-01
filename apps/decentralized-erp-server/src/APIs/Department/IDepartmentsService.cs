using DecentralizedErp.APIs.Common;
using DecentralizedErp.APIs.Dtos;

namespace DecentralizedErp.APIs;

public interface IDepartmentsService
{
    /// <summary>
    /// Create one Department
    /// </summary>
    public Task<Department> CreateDepartment(DepartmentCreateInput department);

    /// <summary>
    /// Delete one Department
    /// </summary>
    public Task DeleteDepartment(DepartmentWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Departments
    /// </summary>
    public Task<List<Department>> Departments(DepartmentFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Department records
    /// </summary>
    public Task<MetadataDto> DepartmentsMeta(DepartmentFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Department
    /// </summary>
    public Task<Department> Department(DepartmentWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Department
    /// </summary>
    public Task UpdateDepartment(
        DepartmentWhereUniqueInput uniqueId,
        DepartmentUpdateInput updateDto
    );
}
