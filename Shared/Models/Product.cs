namespace Resources.Models;

public class Product
{
    public string Name { get; set; } = null!;
    public int Price { get; set; }
    public string Id { get; set; } = Guid.NewGuid().ToString();
}
