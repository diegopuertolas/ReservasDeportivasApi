using Microsoft.AspNetCore.Mvc;
using ReservasDeportivasApi.Models;

namespace ReservasDeportivasApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservasDeportivasController : ControllerBase
{
    private static List<Reserva> reservas = new List<Reserva>
    {
        new Reserva(1, "Diego", "Gimnasio", DateTime.Now, 2, Enums.EstadoReservaEnum.Confirmada, true),
        new Reserva(2, "Hugo", "Pista atletismo", DateTime.Now.AddHours(3), 1, Enums.EstadoReservaEnum.Pendiente,false),
        new Reserva(3, "David", "Campo Fútbol 11", DateTime.Now.AddHours(5), 3, Enums.EstadoReservaEnum.Confirmada, true)
    };    

    [HttpGet]
    public ActionResult<IEnumerable<Reserva>> GetAll()
    {
        return Ok(reservas);
    }

    [HttpGet("{id}")]
    public ActionResult<Reserva> GetById(int id)
    {
        var result = reservas.FirstOrDefault(r => r.Id == id);

        if (result is null) return NotFound();

        return Ok(result);
    }

    [HttpGet("recientes")]
    public ActionResult<IEnumerable<Reserva>> GetReservasRecientes([FromQuery] int cantidad = 5)
    {
        if (cantidad <= 0) return BadRequest();
 
        var result = reservas
            .OrderByDescending(r => r.Fecha)
            .Take(cantidad)
            .ToList();

        if (result.Count == 0) return new List<Reserva>();

        return Ok(result);
    }

    [HttpGet("buscar")]
    public ActionResult<IEnumerable<Reserva>> GetReservasPorNombreCliente([FromQuery] string cliente)
    {
        if (string.IsNullOrWhiteSpace(cliente)) return BadRequest();
 
        var result = reservas
            .Where(r => r.NombreCliente.Contains(cliente, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (result.Count == 0) return new List<Reserva>();
        
        return Ok(result);
    }

    [HttpPost]
    public ActionResult<Reserva> Post([FromBody] Reserva reserva)
    {
        var nuevoId = reservas.Count > 0 ? reservas.Max(r => r.Id) + 1 : 1;

        if (reserva.DuracionHoras <= 0) return BadRequest("La reserva no puede tener una duración menor o igual que 0.");

        reserva.Id = nuevoId;
        reserva.Estado = Enums.EstadoReservaEnum.Pendiente;

        reservas.Add(reserva);

        return CreatedAtAction(nameof(GetById), new { Id = reserva.Id }, reserva);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Reserva reserva)
    {
        var result = reservas.FirstOrDefault(r => r.Id == id);

        if (result is null) return NotFound();

        result.NombreCliente = reserva.NombreCliente;
        result.Instalacion = reserva.Instalacion;
        result.Fecha = reserva.Fecha;
        result.DuracionHoras = reserva.DuracionHoras;
        result.RequiereMaterial = reserva.RequiereMaterial;

        return NoContent();
    }

    [HttpPut("{id}/confirmar")]
    public IActionResult PutConfirmarReserva(int id)
    {
        var result = reservas.FirstOrDefault(r => r.Id == id);

        if (result is null) return NotFound();

        if (result.Estado == Enums.EstadoReservaEnum.Confirmada) return BadRequest();

        result.Estado = Enums.EstadoReservaEnum.Confirmada;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = reservas.FirstOrDefault(r => r.Id == id);

        if (result is null) return NotFound();

        reservas.Remove(result);

        return NoContent();
    }
}