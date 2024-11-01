using DecentralizedErp.APIs;
using DecentralizedErp.APIs.Common;
using DecentralizedErp.APIs.Dtos;
using DecentralizedErp.APIs.Errors;
using DecentralizedErp.APIs.Extensions;
using DecentralizedErp.Infrastructure;
using DecentralizedErp.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DecentralizedErp.APIs;

public abstract class DepartmentsServiceBase : IDepartmentsService
{
    protected readonly DecentralizedErpDbContext _context;

    public DepartmentsServiceBase(DecentralizedErpDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Department
    /// </summary>
    public async Task<Department> CreateDepartment(DepartmentCreateInput createDto)
    {
        var department = new DepartmentDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            department.Id = createDto.Id;
        }

        _context.Departments.Add(department);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<DepartmentDbModel>(department.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Department
    /// </summary>
    public async Task DeleteDepartment(DepartmentWhereUniqueInput uniqueId)
    {
        var department = await _context.Departments.FindAsync(uniqueId.Id);
        if (department == null)
        {
            throw new NotFoundException();
        }

        _context.Departments.Remove(department);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Departments
    /// </summary>
    public async Task<List<Department>> Departments(DepartmentFindManyArgs findManyArgs)
    {
        var departments = await _context
            .Departments.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return departments.ConvertAll(department => department.ToDto());
    }

    /// <summary>
    /// Meta data about Department records
    /// </summary>
    public async Task<MetadataDto> DepartmentsMeta(DepartmentFindManyArgs findManyArgs)
    {
        var count = await _context.Departments.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Department
    /// </summary>
    public async Task<Department> Department(DepartmentWhereUniqueInput uniqueId)
    {
        var departments = await this.Departments(
            new DepartmentFindManyArgs { Where = new DepartmentWhereInput { Id = uniqueId.Id } }
        );
        var department = departments.FirstOrDefault();
        if (department == null)
        {
            throw new NotFoundException();
        }

        return department;
    }

    /// <summary>
    /// Update one Department
    /// </summary>
    public async Task UpdateDepartment(
        DepartmentWhereUniqueInput uniqueId,
        DepartmentUpdateInput updateDto
    )
    {
        var department = updateDto.ToModel(uniqueId);

        _context.Entry(department).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Departments.Any(e => e.Id == department.Id))
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
