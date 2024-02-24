using DomainDrivenDesign.Domain.Categories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Application.Features.Categories.GetAllCategories;

public sealed record GetAllCategoriesQuery:IRequest<IEnumerable<Category>>;
