using LayoutDesigner.Pages;
using Microsoft.AspNetCore.Components;

namespace LayoutDesigner.Models
{
	public class DragInformation
	{
		public Type? ComponentType { get; set; }
		public Dictionary<string, object>? Parameters { get; set; }
		public int CallerIndex { get; set; }
		public DropArea? Caller { get; set; }
		public object? Instance { get; set; }
	}
}
