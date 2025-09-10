using System;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class SortOrderAttribute : Attribute
{
    public int Order { get; }
    public SortOrderAttribute(int order) => Order = order;
}