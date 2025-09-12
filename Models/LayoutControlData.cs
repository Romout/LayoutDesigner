using System.Text.Json.Serialization;
using LayoutDesigner.Components;
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
		[JsonIgnore]
		public Type? Type { get; set; }

		public string TypeName
		{
			get => Type?.FullName ?? "";
			set
			{
				Type = Type.GetType(value);
				if (Type == null)
					throw new Exception($"Type '{value}' not found");
			}
		}

		public Dictionary<string, object> Parameters { get; set; } = new Dictionary<string, object>();
		public bool Selectable { get; set; } = true;
		public bool IsContainer { get; set; } = false;
		public List<LayoutControlData> Children { get; set; } = new List<LayoutControlData>();

		[JsonIgnore]
		public DropArea? DragSource { get; set; }

		public int Width
		{
			get
			{
				if (Parameters != null && Parameters.TryGetValue(nameof(LayoutComponent.Width), out object width))
					return (int)width;
				return 120;
			}
		}

		public int Height
		{
			get
			{
				if (Parameters != null && Parameters.TryGetValue(nameof(LayoutComponent.Height), out object height))
					return (int)height;
				return 40;
			}
		}
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

		[field:JsonIgnore]
		public event Action? ParametersChanged;

        public void SetParameter(string key, object value)
        {
            Parameters[key] = value;
            ParametersChanged?.Invoke();
        }
    }
}
