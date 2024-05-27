
using Microsoft.EntityFrameworkCore;

namespace DemoApp;

public class StudentServices : Istudent
{
    private readonly AppDbContext _appDbContext;
    public StudentServices(AppDbContext appDbContext)
    {
        _appDbContext=appDbContext;
    }
    public async Task<Student> AddStudent(Student newStudent)
    {
        _appDbContext.Students.Add(newStudent);
        await _appDbContext.SaveChangesAsync();
        return newStudent;
    }

    public async Task<Student> GetStudent(Guid Id)
    {
        return await _appDbContext.Students.Where(student=> student.Id==Id).FirstOrDefaultAsync();
    }

    public async Task<List<Student>> GetStudents()
    {
        return await _appDbContext.Students.ToListAsync();
    }
}
