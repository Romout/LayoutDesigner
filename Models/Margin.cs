using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace LayoutDesigner.Models;

[TypeConverter(typeof(MarginTypeConverter))]
public class Margin
{
	public Margin() { }
	public Margin(int left, int top, int right, int bottom)
	{
		Left = left;
		Top = top;
		Right = right;
		Bottom = bottom;
	}

	public int Left { get; set; }
    public int Top { get; set; }
    public int Right { get; set; }
    public int Bottom { get; set; }

    public override string ToString() => $"{Top}px {Right}px {Bottom}px {Left}px";
}

internal class MarginTypeConverter : TypeConverter
{
	private static Regex _regexPattern = new Regex(@"^\s*(?<top>\d+)\s*(px)?\s+(?<right>\d+)\s*(px)?\s+(?<bottom>\d+)\s*(px)?\s+(?<left>\d+)\s*(px)?\s*$", RegexOptions.Compiled);
	public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
	{
        if (typeof(JObject) == sourceType || typeof(string) == sourceType)
            return true;

		return base.CanConvertFrom(context, sourceType);
	}

	public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
	{
		var result = new Margin();
		if (value is JObject json)
		{
			if (json[nameof(Margin.Left)]?.Value<int?>() is int left)
				result.Left = left;
			if (json[nameof(Margin.Top)]?.Value<int?>() is int top)
				result.Top = top;
			if (json[nameof(Margin.Right)]?.Value<int?>() is int right)
				result.Right = right;
			if (json[nameof(Margin.Bottom)]?.Value<int?>() is int bottom)
				result.Bottom = bottom;
			return result;
		}
		else if (value is string text)
		{
			var match = _regexPattern.Match(text);
			if (match.Success)
			{
				result.Left = int.Parse(match.Groups["left"].Value);
				result.Top = int.Parse(match.Groups["top"].Value);
				result.Right = int.Parse(match.Groups["right"].Value);
				result.Bottom = int.Parse(match.Groups["bottom"].Value);
			}
			return result;
		}
		return base.ConvertFrom(context, culture, value);
	}
}