namespace DemoApp;

public interface Istudent
{
    Task<Student> AddStudent (Student newStudent);
    Task<List<Student>> GetStudents();
    Task<Student> GetStudent(Guid Id);

}
