using LayoutDesigner.Components;
using LayoutDesigner.Models;

namespace LayoutDesigner.Services
{
	public class LayoutService
	{
		public LayoutControlData? Payload { get; set; }

		public LayoutControlData Root { get; set; }

		public LayoutControlData? Selection { get; private set; }
		public event Action<LayoutControlData?>? SelectionChanged;
		public event Action<LayoutControlData?>? StateChanged;

		public LayoutService() {
			Root = new LayoutControlData()
			{
				Type = typeof(VerticalPanel),
				Selectable = false,
			};
		}

		public void Select(LayoutControlData? selectedData)
		{
			if (Selection != selectedData)
			{
				Selection = selectedData;
				SelectionChanged?.Invoke(selectedData);
			}
		}
		public void ClearSelection()
		{
			Select(null);
		}

		public void DeleteSelectedComponent()
		{
			if (Selection != null)
				Root.Remove(Selection);
		}

		public void NotifyStateChanged(LayoutControlData data)
		{
			StateChanged?.Invoke(data);
		}
	}
}
