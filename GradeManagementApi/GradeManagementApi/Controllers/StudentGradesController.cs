using GradeManagementApi.Data;
using GradeManagementApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GradeManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentGradesController : ControllerBase
    {
        private readonly GradeManageDbContext _context;

        public StudentGradesController(GradeManageDbContext context)
        {
            _context = context;
        }

        // GET: api/StudentGrades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentGrades>>> GetStudentGrades()
        {
            return await _context.StudentGrades.ToListAsync();
        }

        // GET: api/StudentGrades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentGrades>> GetStudentGrades(int id)
        {
            var studentGrades = await _context.StudentGrades.FindAsync(id);

            if (studentGrades == null)
            {
                return NotFound();
            }

            return studentGrades;
        }

        // PUT: api/StudentGrades/5
        [HttpPut("{id}")]
        public async Task<ActionResult<StudentGrades>> PutStudentGrades(int id, PutStudentGradeDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            var studentGrades = await _context.StudentGrades.FindAsync(id);
            if (studentGrades is null)
                return NotFound();
            studentGrades.FirstName = dto.FirstName;
            studentGrades.LastName = dto.LastName;
            studentGrades.MidTerm = dto.MidTerm;
            studentGrades.Final = dto.Final;
            _context.Update(studentGrades);
            await _context.SaveChangesAsync();

            return studentGrades;
        }

        // POST: api/StudentGrades
        [HttpPost]
        public async Task<ActionResult<StudentGrades>> PostStudentGrades(PostStudentGradeDto dto)
        {
            var studentGrades = new StudentGrades()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                MidTerm = dto.MidTerm,
                Final = dto.Final
            };
            _context.StudentGrades.Add(studentGrades);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentGrades", new { id = studentGrades.Id }, studentGrades);
        }

        // DELETE: api/StudentGrades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentGrades(int id)
        {
            var studentGrades = await _context.StudentGrades.FindAsync(id);
            if (studentGrades == null)
            {
                return NotFound();
            }

            _context.StudentGrades.Remove(studentGrades);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
