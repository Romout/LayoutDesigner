// Components/PropertyGridEditorBase.cs
using Microsoft.AspNetCore.Components;

namespace LayoutDesigner.Components;
public class PropertyGridEditorBase<T> : ComponentBase
{
    [Parameter] public T Value { get; set; }
    [Parameter] public Action<object?> ValueChanged { get; set; }
}