using DecentralizedErp.APIs.Common;
using DecentralizedErp.APIs.Dtos;

namespace DecentralizedErp.APIs;

public interface IFinancesService
{
    /// <summary>
    /// Create one Finance
    /// </summary>
    public Task<Finance> CreateFinance(FinanceCreateInput finance);

    /// <summary>
    /// Delete one Finance
    /// </summary>
    public Task DeleteFinance(FinanceWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Finances
    /// </summary>
    public Task<List<Finance>> Finances(FinanceFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Finance records
    /// </summary>
    public Task<MetadataDto> FinancesMeta(FinanceFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Finance
    /// </summary>
    public Task<Finance> Finance(FinanceWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Finance
    /// </summary>
    public Task UpdateFinance(FinanceWhereUniqueInput uniqueId, FinanceUpdateInput updateDto);
}
