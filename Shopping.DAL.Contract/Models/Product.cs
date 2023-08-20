﻿namespace Shopping.DAL.Contract.Models;

public class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public decimal Price { get; set; }

    public Category? Category { get; set; }
}