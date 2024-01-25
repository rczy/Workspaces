using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Workspaces.Models
{
	public class Assignment
	{
		public int Id { get; set; }
		[DisplayName("Employee")]
		public int EmployeeId { get; set; }
        [DisplayName("Workspace")]
        public int WorkspaceId { get; set; }
        public DateOnly Date { get; set; }
		public virtual Employee? Employee { get; set; }
		public virtual Workspace? Workspace { get; set; }
	}
}
