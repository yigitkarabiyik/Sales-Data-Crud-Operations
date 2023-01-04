using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SalesProject.AddControllers{

  [ApiController]
  [Route("[controller]")]
  public class SalesController : ControllerBase
  {
    private static List<Sales> SalesList = new List<Sales>()
    {
      new Sales{
        Id = 1,
        ProductId = 1, // Shoes
        StoreId = 1, // Cevahir
        Date = new DateTime(2017, 4, 3),
        SalesQuantity = 2,
        Stock = 23
      },
      new Sales{
        Id = 2,
        ProductId = 1, // Shoes
        StoreId = 1, //Cevahir
        Date = new DateTime(2017, 5, 3),
        SalesQuantity = 4,
        Stock = 19
      },
      new Sales{
        Id = 3,
        ProductId = 3, // Jacket
        StoreId = 2, // Istiklal
        Date = new DateTime(2017, 4, 3),
        SalesQuantity = 4,
        Stock = 5
      },
    };

    // api/sales
    [HttpGet]
    public List<Sales> GetSales()
    {
      var salesList = SalesList.OrderBy(x => x.Id).ToList<Sales>();
      return salesList;
    }

    // api/sales/{id}
    [HttpGet("{id}")]
    public Sales GetById(int id)
    {
      var sales = SalesList.Where(sales => sales.Id == id).SingleOrDefault();
      return sales;
    }

    //// api/sales?id={id}
    //[HttpGet]
    //public Sales GetById([FromQuery] string id)
    //{
      //var sales = SalesList.Where(sales => sales.Id == Convert.ToInt32(id)).SingleOrDefault();
      //return sales;
    //}

    [HttpPost]
    public IActionResult AddSales([FromBody] Sales newSales)
    {
      var sales = SalesList.SingleOrDefault(x => x.Id == newSales.Id);
      
      if (sales is not null)
        return BadRequest();
      SalesList.Add(newSales);
      return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateSales(int id, [FromBody] Sales updateSales)
    {
      var sales = SalesList.SingleOrDefault(x => x.Id == id);

      if(sales is null)
        return BadRequest();

      sales.ProductId = updateSales.ProductId != default ? updateSales.ProductId : sales.ProductId;
      sales.StoreId = updateSales.StoreId != default ? updateSales.StoreId : sales.StoreId;
      sales.Date = updateSales.Date != default ? updateSales.Date : sales.Date;
      sales.SalesQuantity = updateSales.SalesQuantity != default ? updateSales.SalesQuantity : sales.SalesQuantity;
      sales.Stock = updateSales.Stock != default ? updateSales.Stock : sales.Stock;

      return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteSales(int id)
    {
      var sales = SalesList.SingleOrDefault(x => x.Id == id);
      if(sales is null)
        return BadRequest();
      SalesList.Remove(sales);
      return Ok();
    }
  }
}