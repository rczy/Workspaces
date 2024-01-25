using Microsoft.EntityFrameworkCore;
using Workspaces.Models;

namespace Workspaces.Data
{
	public class WorkspacesDbContext : DbContext
	{
		public DbSet<Workspace> Workspaces { get; set; }
		public DbSet<Team> Teams { get; set; }
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Assignment> Assignments { get; set; }

		public WorkspacesDbContext(DbContextOptions<WorkspacesDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<Assignment>()
               .HasIndex(a => new { a.EmployeeId, a.Date }).IsUnique();
            modelBuilder.Entity<Workspace>().HasData(
				new Workspace { Id = 1, Name = "10th Floor Office", Capacity = 10 },
				new Workspace { Id = 2, Name = "Ground Floor Room", Capacity = 40 },
				new Workspace { Id = 3, Name = "Basement", Capacity = 20 },
				new Workspace { Id = 4, Name = "Home Office", Capacity = -1 }
			);
			modelBuilder.Entity<Team>().HasData(
				new Team { Id = 1, Name = "Leadership"},
				new Team { Id = 2, Name = "Managers" },
				new Team { Id = 3, Name = "HR" },
				new Team { Id = 4, Name = "Support" },
				new Team { Id = 5, Name = "Developers" }
			);
			modelBuilder.Entity<Employee>().HasData(
				new Employee { Id = 1, Name = "Mr. Boss", TeamId = 1 },
				new Employee { Id = 2, Name = "Zooroid Madshine", TeamId = 1 },
				new Employee { Id = 3, Name = "Bodori Hoborider", TeamId = 2 },
				new Employee { Id = 4, Name = "Fluffbuns Wigglesniff", TeamId = 2 },
				new Employee { Id = 5, Name = "Chewaboo Droopyseed", TeamId = 2 },
				new Employee { Id = 6, Name = "Beaniebs Boombag", TeamId = 3 },
				new Employee { Id = 7, Name = "Bittyitt HippyFadden", TeamId = 3 },
				new Employee { Id = 8, Name = "Dingspitz Woolham", TeamId = 4 },
				new Employee { Id = 9, Name = "Humlu Madborn", TeamId = 4 },
				new Employee { Id = 10, Name = "Weewax Pieham", TeamId = 4 },
				new Employee { Id = 11, Name = "Figman Wigglebrain", TeamId = 4 },
				new Employee { Id = 12, Name = "Binwee Sockhill", TeamId = 5 },
				new Employee { Id = 13, Name = "Beaniepants Beaniegold", TeamId = 5 },
				new Employee { Id = 14, Name = "Figby Madson", TeamId = 5 },
				new Employee { Id = 15, Name = "Jambo Messyman", TeamId = 5 }
			);
			modelBuilder.Entity<Assignment>().HasData(
				new Assignment { Id = 1, EmployeeId = 1, WorkspaceId = 1, Date = DateOnly.Parse("2024-01-15") },
				new Assignment { Id = 2, EmployeeId = 2, WorkspaceId = 1, Date = DateOnly.Parse("2024-01-15") },
				new Assignment { Id = 3, EmployeeId = 3, WorkspaceId = 1, Date = DateOnly.Parse("2024-01-15") },
				new Assignment { Id = 4, EmployeeId = 4, WorkspaceId = 2, Date = DateOnly.Parse("2024-01-15") },
				new Assignment { Id = 5, EmployeeId = 5, WorkspaceId = 2, Date = DateOnly.Parse("2024-01-15") },
				new Assignment { Id = 6, EmployeeId = 6, WorkspaceId = 2, Date = DateOnly.Parse("2024-01-15") },
				new Assignment { Id = 7, EmployeeId = 7, WorkspaceId = 2, Date = DateOnly.Parse("2024-01-15") },
				new Assignment { Id = 8, EmployeeId = 8, WorkspaceId = 2, Date = DateOnly.Parse("2024-01-15") },
				new Assignment { Id = 9, EmployeeId = 9, WorkspaceId = 2, Date = DateOnly.Parse("2024-01-15") },
				new Assignment { Id = 10, EmployeeId = 10, WorkspaceId = 2, Date = DateOnly.Parse("2024-01-15") },
				new Assignment { Id = 11, EmployeeId = 11, WorkspaceId = 2, Date = DateOnly.Parse("2024-01-15") },
				new Assignment { Id = 12, EmployeeId = 12, WorkspaceId = 3, Date = DateOnly.Parse("2024-01-15") },
				new Assignment { Id = 13, EmployeeId = 13, WorkspaceId = 3, Date = DateOnly.Parse("2024-01-15") },
				new Assignment { Id = 14, EmployeeId = 14, WorkspaceId = 3, Date = DateOnly.Parse("2024-01-15") },
				new Assignment { Id = 15, EmployeeId = 15, WorkspaceId = 3, Date = DateOnly.Parse("2024-01-15") },
				new Assignment { Id = 16, EmployeeId = 1, WorkspaceId = 4, Date = DateOnly.Parse("2024-01-16") },
				new Assignment { Id = 17, EmployeeId = 2, WorkspaceId = 1, Date = DateOnly.Parse("2024-01-16") },
				new Assignment { Id = 18, EmployeeId = 3, WorkspaceId = 1, Date = DateOnly.Parse("2024-01-16") },
				new Assignment { Id = 19, EmployeeId = 4, WorkspaceId = 1, Date = DateOnly.Parse("2024-01-16") },
				new Assignment { Id = 20, EmployeeId = 5, WorkspaceId = 1, Date = DateOnly.Parse("2024-01-16") },
				new Assignment { Id = 21, EmployeeId = 6, WorkspaceId = 1, Date = DateOnly.Parse("2024-01-16") },
				new Assignment { Id = 22, EmployeeId = 7, WorkspaceId = 2, Date = DateOnly.Parse("2024-01-16") },
				new Assignment { Id = 23, EmployeeId = 8, WorkspaceId = 2, Date = DateOnly.Parse("2024-01-16") },
				new Assignment { Id = 24, EmployeeId = 9, WorkspaceId = 2, Date = DateOnly.Parse("2024-01-16") },
				new Assignment { Id = 25, EmployeeId = 10, WorkspaceId = 3, Date = DateOnly.Parse("2024-01-16") },
				new Assignment { Id = 26, EmployeeId = 11, WorkspaceId = 3, Date = DateOnly.Parse("2024-01-16") },
				new Assignment { Id = 27, EmployeeId = 12, WorkspaceId = 4, Date = DateOnly.Parse("2024-01-16") },
				new Assignment { Id = 28, EmployeeId = 13, WorkspaceId = 4, Date = DateOnly.Parse("2024-01-16") },
				new Assignment { Id = 29, EmployeeId = 14, WorkspaceId = 1, Date = DateOnly.Parse("2024-01-16") },
				new Assignment { Id = 30, EmployeeId = 15, WorkspaceId = 3, Date = DateOnly.Parse("2024-01-16") }
			);
		}
	}
}
