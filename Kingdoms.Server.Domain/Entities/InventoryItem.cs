﻿using System.ComponentModel.DataAnnotations;

namespace Kingdoms.Server.Domain.Entities;

public class InventoryItem
{
    [Key]
    public int Id { get; set; }

    public Guid InventoryId { get; set; }
    public Inventory Inventory { get; set; }
    public int ItemId { get; set; }
    public Item Item { get; set; }
    public int Quantity { get; set; }
}