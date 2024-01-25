using System.ComponentModel;

namespace Workspaces.Models
{
	public class Employee
	{
		public int Id { get; set; }
		public string Name { get; set; }
        [DisplayName("Team")]
        public int TeamId { get; set; }
		public virtual Team? Team { get; set; }
	}
}
