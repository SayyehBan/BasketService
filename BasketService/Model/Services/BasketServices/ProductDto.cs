﻿namespace BasketService.Model.Services.BasketServices;

public class ProductDto
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public int UnitPrice { get; set; }
    public string ImageUrl { get; set; }
}
