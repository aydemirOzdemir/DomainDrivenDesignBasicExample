﻿using DomainDrivenDesign.Domain.Abstraction;
using DomainDrivenDesign.Domain.Categories;
using DomainDrivenDesign.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Products;

public sealed class Product:Entity
{
    private Product(Guid id) : base(id) { }
    public Product(Guid id,Name name, int quantity, Money price, Guid categoryId):base(id)
    {
        Name = name;
        Quantity = quantity;
        Price = price;
        CategoryId = categoryId;

    }

    public Name Name { get; private set; }
    public int Quantity { get; private set; }
    public Money Price { get; private set; }
    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; }
    public void Update(string name,decimal amount,string currency,Guid categoryId,int quantity)
    {
        Name=new Name(name);
        Quantity=quantity;
        Price = new Money(amount, Currency.FromCode(currency));
        CategoryId = categoryId;

    }
}
