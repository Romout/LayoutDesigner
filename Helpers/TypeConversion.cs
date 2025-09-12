using System.ComponentModel;

namespace LayoutDesigner.Helpers
{
	public static class TypeConversion
	{
		public static object? Convert(object? value, Type targetType)
		{
			if (value == null || targetType.IsInstanceOfType(value))
				return value;

			var converter = TypeDescriptor.GetConverter(targetType);
			if (converter.CanConvertFrom(value.GetType()))
				return converter.ConvertFrom(value);

			return System.Convert.ChangeType(value, targetType);
		}
	}
}
