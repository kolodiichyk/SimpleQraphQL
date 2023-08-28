namespace SimpleGraphQL.Models;

public class Product
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public Manufacturer Manufacturer { get; set; }
}