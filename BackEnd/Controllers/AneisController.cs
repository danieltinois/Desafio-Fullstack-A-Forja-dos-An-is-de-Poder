using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnelPowerAPI.Data;
using AnelPowerAPI.Models;

namespace AnelPowerAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AnéisController : ControllerBase
  {
    private readonly ApplicationDbContext _context;

    public AnéisController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET: api/Anéis
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Anel>>> GetAnéis()
    {
      return await _context.Anéis.ToListAsync();
    }

    // POST: api/Anéis
    [HttpPost]
    public async Task<ActionResult<Anel>> PostAnel(Anel anel)
    {
      // Validação: número de anéis por portador
      int elfosCount = _context.Anéis.Count(a => a.Portador == "Elfo");
      int anoesCount = _context.Anéis.Count(a => a.Portador == "Anão");
      int homensCount = _context.Anéis.Count(a => a.Portador == "Homem");
      int sauronCount = _context.Anéis.Count(a => a.Portador == "Sauron");

      if ((anel.Portador == "Elfo" && elfosCount >= 3) ||
          (anel.Portador == "Anão" && anoesCount >= 7) ||
          (anel.Portador == "Homem" && homensCount >= 9) ||
          (anel.Portador == "Sauron" && sauronCount >= 1))
      {
        return BadRequest("Limite de anéis excedido.");
      }

      _context.Anéis.Add(anel);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetAnéis", new { id = anel.Id }, anel);
    }

    // PUT: api/Anéis/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAnel(int id, Anel anel)
    {
      if (id != anel.Id)
      {
        return BadRequest();
      }

      // Verifique se o portador foi alterado
      var anelExistente = await _context.Anéis.FindAsync(id);
      if (anelExistente == null)
      {
        return NotFound();
      }

      string portadorAntigo = anelExistente.Portador;
      string portadorNovo = anel.Portador;

      // Se o portador foi alterado, verifique o limite de anéis para o novo portador
      if (portadorAntigo != portadorNovo)
      {
        // Contagem de anéis do novo portador
        int elfosCount = _context.Anéis.Count(a => a.Portador == "Elfo");
        int anoesCount = _context.Anéis.Count(a => a.Portador == "Anão");
        int homensCount = _context.Anéis.Count(a => a.Portador == "Homem");
        int sauronCount = _context.Anéis.Count(a => a.Portador == "Sauron");

        if ((portadorNovo == "Elfo" && elfosCount >= 3) ||
            (portadorNovo == "Anão" && anoesCount >= 7) ||
            (portadorNovo == "Homem" && homensCount >= 9) ||
            (portadorNovo == "Sauron" && sauronCount >= 1))
        {
          return BadRequest("Limite de anéis excedido para o novo portador.");
        }
      }

      // Atualize o anel com os novos dados
      _context.Entry(anelExistente).CurrentValues.SetValues(anel);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    // DELETE: api/Anéis/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnel(int id)
    {
      var anel = await _context.Anéis.FindAsync(id);
      if (anel == null)
      {
        return NotFound();
      }

      _context.Anéis.Remove(anel);
      await _context.SaveChangesAsync();

      return NoContent();
    }
  }
}
