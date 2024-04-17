namespace LayoutDesigner.Interfaces
{
    public interface ILayoutComponent
    {
        public Guid Id { get; set; }
        public bool PreviewMode { get; set; }
        public bool DesignMode { get; set; }
    }
}
