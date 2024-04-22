using Microsoft.AspNetCore.Mvc;
using StudentRestApi.Models;

namespace StudentRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Student>>> Search(string name, Gender? gender)
        {
            try
            {
                var result = await studentRepository.Search(name, gender);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult> GetStudents()
        {
            try
            {
                return Ok(await studentRepository.GetStudents());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            try
            {
                var result = await studentRepository.GetStudent(id);
                if(result!= null)
                {
                    return Ok();
                }
                return NotFound();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            try
            {
                if(student == null)
                {
                    return BadRequest();
                }
                var stu = await studentRepository.GetStudentByEmail(student.Email);
                if (stu != null)
                {
                    ModelState.AddModelError("Email", "Student Email already in use");
                    return BadRequest(ModelState);
                }
                var newStudent = await studentRepository.AddStudent(student);
                return CreatedAtAction(nameof(GetStudent), new { id = newStudent.StudentId }, newStudent);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new student");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, Student student)
        {
            try
            {
                if (id != student.StudentId)
                {
                    return BadRequest("Student ID mismatch");
                }
                var studentToUpdate = await studentRepository.GetStudent(id);
                if (studentToUpdate == null)
                {
                    return NotFound($"Student with Id = {id} not found.");
                }
                return await studentRepository.UpdateStudent(student);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating student record");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            try
            {
                var studentToDelete = await studentRepository.GetStudent(id);
                if(studentToDelete == null)
                {
                    return NotFound($"Student with id {id} not found.");
                }
                await studentRepository.DeleteStudent(id);
                return Ok($"Student with id {id} successfully deleted.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting student.");
            }
        }



    }
}
