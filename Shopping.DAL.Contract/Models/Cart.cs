namespace Shopping.DAL.Contract.Models;

public class Cart
{
    public int Id { get; set; }

    public List<ProductItem>? ProductItems { get; set; }

    public int UserId { get; set; }
}