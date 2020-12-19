namespace csAmazen.Models
{
  public class Item
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal SalePrice { get; set; }

    public string[] Tags { get; set; }
    public string[] Options { get; set; }
    public string Picture { get; set; }
    public int Quantity { get; set; }

    public int Id { get; set; }

    public int Rating { get; set; }
    public bool IsAvailable { get; set; }

    public string CreatorId { get; set; }

    public Profile Creator { get; set; }

  }

  public class ListItemViewModel : Item
  {
    public int ListItemId { get; set; }
  }
}