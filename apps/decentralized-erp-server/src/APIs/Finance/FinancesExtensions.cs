using DecentralizedErp.APIs.Dtos;
using DecentralizedErp.Infrastructure.Models;

namespace DecentralizedErp.APIs.Extensions;

public static class FinancesExtensions
{
    public static Finance ToDto(this FinanceDbModel model)
    {
        return new Finance
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static FinanceDbModel ToModel(
        this FinanceUpdateInput updateDto,
        FinanceWhereUniqueInput uniqueId
    )
    {
        var finance = new FinanceDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            finance.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            finance.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return finance;
    }
}
