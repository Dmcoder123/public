﻿using System.ComponentModel.DataAnnotations;

namespace Renfield.Inventory.Data
{
  public class Company
  {
    public int Id { get; set; }

    [StringLength(256)]
    public string Name { get; set; }
  }
}