﻿using SayyehBanTools.Calc;

namespace BasketService.Model.Services.BasketServices;

public class BasketDto
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public Guid? DiscountId { get; set; }
    public List<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();
    public int Total()
    {
        if (Items.Count > 0)
        {
            int total = Items.Sum(p => Convert.ToInt32(Calculator.Multiply(p.UnitPrice, p.Quantity)));
            return total;
        }
        return 0;
    }

}
