﻿using BasketService.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasketService.Infrastructure.Contexts;
public class BasketDataBaseContext : DbContext
{
    public BasketDataBaseContext(DbContextOptions<BasketDataBaseContext> options)
   : base(options)
    {

    }

    public DbSet<Basket> Baskets { get; set; }
    public DbSet<BasketItem> BasketItems { get; set; }
}