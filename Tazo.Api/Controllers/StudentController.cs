using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tazo.DataAccess.Data;
using Tazo.Models.Entities;

namespace Tazo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _db;

        public StudentController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            return Ok(await _db.Students.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await _db.Students.FindAsync(id);

            if (student is null){
                 return NotFound();
            }else{
                 return Ok(student);
            }
               

           
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            if (student is null)
                return BadRequest();

            _db.Students.Add(student);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudentById), new { id = student.StudentId }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student updatedStudent)
        {
            var student = await _db.Students.FindAsync(id);

            if (student is null)
                return NotFound();

            student.Name = updatedStudent.Name;
            student.Email = updatedStudent.Email;
            student.EnrollmentDate = updatedStudent.EnrollmentDate;

            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _db.Students.FindAsync(id);

            if (student is null)
                return NotFound();

            _db.Students.Remove(student);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
