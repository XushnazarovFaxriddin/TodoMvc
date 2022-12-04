using Microsoft.EntityFrameworkCore;
using TodoMvcApp.Models;

namespace TodoMvcApp.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options):base(options) { }

		public DbSet<Todo> Todos { get; set; }
	}
}
