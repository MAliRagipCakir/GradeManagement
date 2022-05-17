using GradeManagementData.EntityFramework.Abstract;
using GradeManagementModel.Concrete;
using GradeManagementModel.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GradeManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentGradesController : ControllerBase
    {
        private readonly IStudentGradeRepository _studentGradeRepository;

        public StudentGradesController(IStudentGradeRepository studentGradeRepository)
        {
            _studentGradeRepository = studentGradeRepository;
        }

        // GET: api/StudentGrades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentGrade>>> GetStudentGrades()
        {
            var list = await _studentGradeRepository.GetAll();
            return list;
        }

        // GET: api/StudentGrades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentGrade>> GetStudentGrades(Guid id)
        {
            var studentGrade = await _studentGradeRepository.GetByID(id);

            if (studentGrade == null)
            {
                return NotFound();
            }

            return studentGrade;
        }

        // PUT: api/StudentGrades/5
        [HttpPut("{id}")]
        public async Task<ActionResult<StudentGrade>> PutStudentGrades(Guid id, PutStudentGradeDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            var studentGrade = await _studentGradeRepository.GetByID(id);
            if (studentGrade is null)
                return NotFound();
            studentGrade.FirstName = dto.FirstName;
            studentGrade.LastName = dto.LastName;
            studentGrade.MidTerm = dto.MidTerm;
            studentGrade.Final = dto.Final;
            await _studentGradeRepository.Update(studentGrade);

            return studentGrade;
        }

        // POST: api/StudentGrades
        [HttpPost]
        public async Task<ActionResult<StudentGrade>> PostStudentGrades(PostStudentGradeDto dto)
        {
            var studentGrade = new StudentGrade()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                MidTerm = dto.MidTerm,
                Final = dto.Final
            };
            await _studentGradeRepository.Add(studentGrade);

            return CreatedAtAction("GetStudentGrades", new { id = studentGrade.Id }, studentGrade);
        }

        // DELETE: api/StudentGrades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentGrades(Guid id)
        {
            var studentGrade = await _studentGradeRepository.GetByID(id);
            if (studentGrade == null)
            {
                return NotFound();
            }

            await _studentGradeRepository.Delete(studentGrade);

            return NoContent();
        }
    }
}
