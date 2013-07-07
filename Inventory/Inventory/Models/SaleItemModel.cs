﻿using System.ComponentModel.DataAnnotations;
using Renfield.Inventory.Data;
using Renfield.Inventory.Helpers;

namespace Renfield.Inventory.Models
{
  public class SaleItemModel
  {
    public int Id { get; set; }

    [Display(Name = "Product Name")]
    public string ProductName { get; set; }

    public string Quantity { get; set; }
    public string Price { get; set; }

    public string Value { get; set; }

    public static SaleItemModel From(SaleItem value)
    {
      return new SaleItemModel
      {
        Id = value.Id,
        ProductName = value.Product.Name,
        Quantity = value.Quantity.Formatted(),
        Price = value.Price.Formatted(),
        Value = (value.Quantity * value.Price).Formatted(),
      };
    }

    public bool IsValid()
    {
      return !ProductName.IsNullOrEmpty() &&
             !Quantity.IsNullOrEmpty() &&
             !Price.IsNullOrEmpty();
    }
  }
}