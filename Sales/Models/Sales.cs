using System;

namespace SalesProject
{
  public class Sales
  {
    public int Id { get; set; } 
    public int ProductId { get; set; } 
    public int StoreId { get; set; } 
    public DateTime Date { get; set; } 
    public int SalesQuantity { get; set; }
    public int Stock { get; set; }

  }
}