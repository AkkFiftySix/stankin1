namespace stankin1.Models;

public class Student
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public int CityId { get; set; }
    public City City { get; set; }

    public int DegreeId { get; set; }
    public Degree Degree { get; set; }

    public int DepartmentId { get; set; }
    public Department Department { get; set; }

    public int? JobId { get; set; }
    public Job Job { get; set; }
}