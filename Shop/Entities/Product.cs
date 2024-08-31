namespace Shop.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    //public Order Order { get; set; }
    public ICollection<Order> Orders { get; set; }
}
