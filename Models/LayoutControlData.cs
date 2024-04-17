using LayoutDesigner.Pages;

namespace LayoutDesigner.Models
{
	public class LayoutControlData
	{
		public Type? Type { get; set; }
		public Dictionary<string, object> Parameters { get; set; } = new Dictionary<string, object>();
		public bool Selectable { get; set; } = true;
		public bool IsContainer { get; set; } = false;
		public List<LayoutControlData> Children { get; set; } = new List<LayoutControlData>();
		public DropArea? DragSource { get; set; }
	}
}
