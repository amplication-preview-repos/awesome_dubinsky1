using DecentralizedErp.APIs;
using DecentralizedErp.APIs.Common;
using DecentralizedErp.APIs.Dtos;
using DecentralizedErp.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace DecentralizedErp.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class FinancesControllerBase : ControllerBase
{
    protected readonly IFinancesService _service;

    public FinancesControllerBase(IFinancesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Finance
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Finance>> CreateFinance(FinanceCreateInput input)
    {
        var finance = await _service.CreateFinance(input);

        return CreatedAtAction(nameof(Finance), new { id = finance.Id }, finance);
    }

    /// <summary>
    /// Delete one Finance
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteFinance([FromRoute()] FinanceWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteFinance(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Finances
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Finance>>> Finances(
        [FromQuery()] FinanceFindManyArgs filter
    )
    {
        return Ok(await _service.Finances(filter));
    }

    /// <summary>
    /// Meta data about Finance records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> FinancesMeta(
        [FromQuery()] FinanceFindManyArgs filter
    )
    {
        return Ok(await _service.FinancesMeta(filter));
    }

    /// <summary>
    /// Get one Finance
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Finance>> Finance([FromRoute()] FinanceWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Finance(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Finance
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateFinance(
        [FromRoute()] FinanceWhereUniqueInput uniqueId,
        [FromQuery()] FinanceUpdateInput financeUpdateDto
    )
    {
        try
        {
            await _service.UpdateFinance(uniqueId, financeUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
