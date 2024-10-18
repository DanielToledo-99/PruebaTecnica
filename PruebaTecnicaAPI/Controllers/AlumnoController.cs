using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AlumnosController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AlumnosController(ApplicationDbContext context)
    {
        _context = context;
    }
    [HttpGet("aula/{aulaId}")]
    public async Task<ActionResult<IEnumerable<AlumnoDto>>> GetAlumnosPorAula(int aulaId, [FromQuery] int? docenteId)
    {
        var aula = await _context.Aulas
            .Include(a => a.Docente)
            .FirstOrDefaultAsync(a => a.AulaID == aulaId);

        if (aula == null)
            return NotFound("Aula no encontrada");
        if (docenteId.HasValue && aula.DocenteID != docenteId)
            return Forbid("El docente no tiene acceso a esta aula");

        var alumnos = await _context.Alumnos
            .Where(a => a.AulaID == aulaId)
            .Select(a => new AlumnoDto
            {
                AlumnoID = a.AlumnoID,
                Nombre = a.Nombre,
                Edad = a.Edad,
                AulaID = a.AulaID
            })
            .ToListAsync();

        return Ok(alumnos);
    }
    [HttpPost("asignar")]
    public async Task<IActionResult> AsignarAlumnoAula([FromBody] AlumnoDto alumnoDto)
    {
        var aula = await _context.Aulas
            .Include(a => a.Alumnos)
            .FirstOrDefaultAsync(a => a.AulaID == alumnoDto.AulaID);

        if (aula == null)
            return NotFound("Aula no encontrada");

        if (aula.Alumnos.Count >= 5)
            return BadRequest("El aula ha alcanzado su capacidad máxima de 5 alumnos");

        var alumno = new Alumno
        {
            Nombre = alumnoDto.Nombre,
            Edad = alumnoDto.Edad,
            AulaID = alumnoDto.AulaID
        };

        _context.Alumnos.Add(alumno);
        await _context.SaveChangesAsync();

        return Ok(alumno);
    }

    // Actualizar información de alumno
    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarAlumno(int id, [FromBody] AlumnoDto alumnoDto)
    {
        var alumno = await _context.Alumnos.FindAsync(id);

        if (alumno == null)
            return NotFound();

        alumno.Nombre = alumnoDto.Nombre;
        alumno.Edad = alumnoDto.Edad;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AlumnoExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarAlumno(int id)
    {
        var alumno = await _context.Alumnos.FindAsync(id);
        if (alumno == null)
            return NotFound();

        _context.Alumnos.Remove(alumno);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AlumnoExists(int id)
    {
        return _context.Alumnos.Any(e => e.AlumnoID == id);
    }
}