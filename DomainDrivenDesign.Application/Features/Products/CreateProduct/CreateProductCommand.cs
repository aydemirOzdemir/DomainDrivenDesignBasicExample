﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Application.Features.Products.CreateProduct;

public sealed record CreateProductCommand(string name, int quantity, decimal amount, string currency, Guid categoryId):IRequest;
