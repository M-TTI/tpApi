using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tpApi.Attributes;
using tpApi.Data;
using tpApi.Models;

namespace tpApi.Controllers;

[ApiController]
[Route("/forecasts")]
[TokenAuth]
public class ForecastController(AppDbContext _context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Forecast>>> List()
    {
        return await _context.Forecasts.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Forecast>> Show(int id)
    {
        var forecast = await _context.Forecasts.FindAsync(id);

        if (null == forecast)
        {
            return NotFound();
        }

        return forecast;
    }

    [HttpPost]
    public async Task<ActionResult<Forecast>> Create(Forecast forecast)
    {
        _context.Forecasts.Add(forecast);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Show), new { id = forecast.Id }, forecast);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var forecast = await _context.Forecasts.FindAsync(id);
        if (null == forecast)
        {
            return NotFound();
        }

        _context.Forecasts.Remove(forecast);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}