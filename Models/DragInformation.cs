using LayoutDesigner.Pages;
using Microsoft.AspNetCore.Components;

namespace LayoutDesigner.Models
{
	public class DragInformation
	{
		public DynamicComponent? Instance { get; set; }
		public int CallerIndex { get; set; }
		public DropArea? Caller { get; set; }
	}
}
