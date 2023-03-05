using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stankin1.Data;
using stankin1.Models;

namespace stankin1.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{

    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public StudentController(DataContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("get-students")]
    public async Task<StudentDto[]> GetStudents()
    {
        var students = await _context.Students
            .Include(s => s.City)
            .Include(s => s.Job)
            .Include(s => s.Degree)
            .Include(s => s.Department)
            .ToArrayAsync();

        return _mapper.Map<StudentDto[]>(students);
    }
}