using DecentralizedErp.APIs;
using DecentralizedErp.APIs.Common;
using DecentralizedErp.APIs.Dtos;
using DecentralizedErp.APIs.Errors;
using DecentralizedErp.APIs.Extensions;
using DecentralizedErp.Infrastructure;
using DecentralizedErp.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DecentralizedErp.APIs;

public abstract class FinancesServiceBase : IFinancesService
{
    protected readonly DecentralizedErpDbContext _context;

    public FinancesServiceBase(DecentralizedErpDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Finance
    /// </summary>
    public async Task<Finance> CreateFinance(FinanceCreateInput createDto)
    {
        var finance = new FinanceDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            finance.Id = createDto.Id;
        }

        _context.Finances.Add(finance);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<FinanceDbModel>(finance.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Finance
    /// </summary>
    public async Task DeleteFinance(FinanceWhereUniqueInput uniqueId)
    {
        var finance = await _context.Finances.FindAsync(uniqueId.Id);
        if (finance == null)
        {
            throw new NotFoundException();
        }

        _context.Finances.Remove(finance);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Finances
    /// </summary>
    public async Task<List<Finance>> Finances(FinanceFindManyArgs findManyArgs)
    {
        var finances = await _context
            .Finances.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return finances.ConvertAll(finance => finance.ToDto());
    }

    /// <summary>
    /// Meta data about Finance records
    /// </summary>
    public async Task<MetadataDto> FinancesMeta(FinanceFindManyArgs findManyArgs)
    {
        var count = await _context.Finances.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Finance
    /// </summary>
    public async Task<Finance> Finance(FinanceWhereUniqueInput uniqueId)
    {
        var finances = await this.Finances(
            new FinanceFindManyArgs { Where = new FinanceWhereInput { Id = uniqueId.Id } }
        );
        var finance = finances.FirstOrDefault();
        if (finance == null)
        {
            throw new NotFoundException();
        }

        return finance;
    }

    /// <summary>
    /// Update one Finance
    /// </summary>
    public async Task UpdateFinance(FinanceWhereUniqueInput uniqueId, FinanceUpdateInput updateDto)
    {
        var finance = updateDto.ToModel(uniqueId);

        _context.Entry(finance).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Finances.Any(e => e.Id == finance.Id))
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
