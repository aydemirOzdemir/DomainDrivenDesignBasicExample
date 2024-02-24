using DomainDrivenDesign.Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Application.Features.Products.GetAllProducts;

public sealed  record GetAllProductsQuery():IRequest<IEnumerable<Product>>;
