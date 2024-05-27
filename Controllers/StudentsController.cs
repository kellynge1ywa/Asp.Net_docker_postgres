using Microsoft.AspNetCore.Mvc;

namespace DemoApp;
[Route("api/[controller]")]
[ApiController]

public class StudentsController:ControllerBase
{
    private readonly Istudent _studentServices;
    private readonly ResponseDto _responseDto;
    public StudentsController(Istudent studentServices)
    {
        _studentServices=studentServices;
        _responseDto=new ResponseDto();
    }

    [HttpGet]
    public async Task<ActionResult<ResponseDto>> GetStudents()
    {
        try
        {
            var students= await _studentServices.GetStudents();
            if(students != null)
            {
                _responseDto.Result=students;
                return Ok(_responseDto);
            }
            _responseDto.Error="Students not found";
            return NotFound(_responseDto);

        }
        catch (Exception ex)
        {
            _responseDto.Error = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            return StatusCode(500, _responseDto);
        }

    }
    [HttpGet("/{studentId}")]
    public async Task<ActionResult<ResponseDto>> GetStudent(Guid studentId)
    {
        try
        {
            var student= await _studentServices.GetStudent(studentId);
            if(student != null)
            {
                _responseDto.Result=student;
                return Ok(_responseDto);
            }
            _responseDto.Error="Student not found";
            return NotFound(_responseDto);

        }
        catch (Exception ex)
        {
            _responseDto.Error = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            return StatusCode(500, _responseDto);
        }
    }

    [HttpPost("Add")]
    public async Task<ActionResult<ResponseDto>> AddStudent(AddStudentDto addStudent)
    {
        try
        {
            var newstudent= new Student()
            {
                Id=new Guid(),
                StudentName=addStudent.StudentName,
                Class=addStudent.Class,
                Stream=addStudent.Stream
            };

            var student= await _studentServices.AddStudent(newstudent);

            _responseDto.Result=student;
            return Created("",_responseDto);

        }
        catch (Exception ex)
        {
            _responseDto.Error = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            return StatusCode(500, _responseDto);
        }
    }


}


