
using Microsoft.EntityFrameworkCore;

namespace StudentRestApi.Models
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext appDbContext;
        public StudentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Student> AddStudent(Student student)
        {
            var result = await appDbContext.Students.AddAsync(student);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteStudent(int id)
        {
            var result = await appDbContext.Students.FirstOrDefaultAsync(e=> e.StudentId == id);
            if( result!= null)
            {
                appDbContext.Students.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Student> GetStudent(int id)
        {
            var result = await appDbContext.Students.FirstOrDefaultAsync(e=> e.StudentId==id);
            return result;
        }

        public async Task<Student> GetStudentByEmail(string Email)
        {
            var result = await appDbContext.Students.FirstOrDefaultAsync(e=> e.Email==Email);
            return result;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            var result = await appDbContext.Students.ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Student>> Search(string name, Gender? gender)
        {
            IQueryable<Student> query = appDbContext.Students;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e=> e.FirstName.Contains(name) ||
                e.LastName.Contains(name));
            }
            if(gender != null)
            {
                query = query.Where(e => e.Gender == gender);
            }
            var result = await query.ToListAsync();
            return result;
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            var result = await appDbContext.Students.FirstOrDefaultAsync();
            if (result != null)
            {
                result.FirstName = student.FirstName;
                result.LastName = student.LastName;
                result.Gender = student.Gender;
                result.Email = student.Email;
                result.DepartmentId = student.DepartmentId;
            }
            await appDbContext.SaveChangesAsync();
            return result;
        }
    }
}
