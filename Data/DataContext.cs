using Microsoft.EntityFrameworkCore;
using stankin1.Models;

namespace stankin1.Data;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions<DataContext> options): base(options) { }

	public DbSet<Student> Students { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Degree> Degrees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Job> Jobs { get; set; }
}
