namespace WebApp.Composite.Composite
{
    public interface IBookComponent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        int Count();
        string Display();
    }
}
