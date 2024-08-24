using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ColaboradoresController : ControllerBase
{
    private readonly RRHHContext _context;

    public ColaboradoresController(RRHHContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetColaboradores()
    {
        return Ok(await _context.Colaboradores.Include(c => c.Clientes).ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetColaboradorById(int id)
    {
        var colaborador = await _context.Colaboradores.Include(c => c.Clientes)
                                                      .FirstOrDefaultAsync(c => c.ColaboradorId == id);
        if (colaborador == null)
            return NotFound();

        return Ok(colaborador);
    }

    [HttpPost]
    public async Task<IActionResult> CreateColaborador([FromBody] Colaborador colaborador)
    {
        _context.Colaboradores.Add(colaborador);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetColaboradorById), new { id = colaborador.ColaboradorId }, colaborador);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateColaborador(int id, [FromBody] Colaborador colaborador)
    {
        if (id != colaborador.ColaboradorId)
            return BadRequest();

        _context.Entry(colaborador).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Colaboradores.Any(e => e.ColaboradorId == id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteColaborador(int id)
    {
        var colaborador = await _context.Colaboradores.FindAsync(id);
        if (colaborador == null)
            return NotFound();

        _context.Colaboradores.Remove(colaborador);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
