using AutoMapper;
using stankin1.Interfaces;

namespace stankin1.Models;

public class StudentDto : IHaveCustomMapping
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public string CityName { get; set; }

    public string DegreeName { get; set; }

    public string DepartmentName { get; set; }

    public string JobName { get; set; }

    public void CreateMappings(Profile configuration)
    {
        configuration.CreateMap<Student, StudentDto>()
            .ForMember(x => x.DepartmentName, x => x.MapFrom(x => x.Department.Name))
            .ForMember(x => x.CityName, x => x.MapFrom(x => x.City.Name))
            .ForMember(x => x.DegreeName, x => x.MapFrom(x => x.Degree.Name))
            .ForMember(x => x.JobName, x => x.MapFrom(x => x.Job.Name))
            .ReverseMap();
    }
}
