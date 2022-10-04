namespace PointOfSale.Models;

public class Item
{
    public int Id { get; set; }

    public string Title { get; set; }

    public int Quantity { get; set; }

    public string Image { get; set; }

    public double Price { get; set; }

    public ItemCategory Category { get; set; }

    public double SubTotal {
        get
        {
            return Price * Quantity;
        }
    }
}