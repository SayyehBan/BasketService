﻿namespace BasketService.Model.Entities;

public class Basket
{
    public Basket(string UserId)
    {
        this.UserId = UserId;
    }
    public Basket()
    {
    }
    public Guid Id { get; set; }
    public string UserId { get; private set; }

    public List<BasketItem> Items { get; set; } = new List<BasketItem>();
}
