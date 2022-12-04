using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoMvcApp.Models
{
	public class Todo
	{
		public int Id { get; set; }

		[MinLength(5), MaxLength(255)]
		public string Title { get; set; }

		[DefaultValue(false)]
		public bool IsDone { get; set; }
		public DateTime CreateDate
		{
			get => (DateTime)(_dateTimeNow == null ? DateTime.Now : _dateTimeNow);
			set => _dateTimeNow = value;
		}

		private DateTime? _dateTimeNow = null;
	}
}
