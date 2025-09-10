// Components/PropertyGridUIEditorAttribute.cs
using System;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class PropertyGridUIEditorAttribute : Attribute
{
    public Type EditorComponentType { get; }
    public PropertyGridUIEditorAttribute(Type editorComponentType)
    {
        EditorComponentType = editorComponentType;
    }
}