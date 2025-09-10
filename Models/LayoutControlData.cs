using LayoutDesigner.Pages;

namespace LayoutDesigner.Models
{
	public class LayoutControlData
	{
		private static int counter = 0;

		public LayoutControlData()
		{
			ObjectID = counter++;
		}

		public int ObjectID { get; }
		public Type? Type { get; set; }
		public Dictionary<string, object> Parameters { get; set; } = new Dictionary<string, object>();
		public bool Selectable { get; set; } = true;
		public bool IsContainer { get; set; } = false;
		public List<LayoutControlData> Children { get; set; } = new List<LayoutControlData>();
		public DropArea? DragSource { get; set; }


		public bool Remove(LayoutControlData item)
		{
			int i;
			bool found = false;
			for (i = 0; i < Children.Count; ++i)
			{
				if (Children[i] == item)
				{
					found = true;
					break;
				}
			}

			if (found)
				Children.RemoveAt(i);
			else
			{
				foreach (var child in Children)
				{
					if (child.Remove(item))
						return true;
				}
			}
			return found;
		}

        public event Action? ParametersChanged;

        public void SetParameter(string key, object value)
        {
            Parameters[key] = value;
            ParametersChanged?.Invoke();
        }
    }
}
