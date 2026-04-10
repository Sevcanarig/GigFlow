using GigFlow.Application.Features.Categories.Dtos;
using MediatR;

namespace GigFlow.Application.Features.Categories.Queries.GetAllCategories;

public class GetAllCategoriesQuery : IRequest<List<CategoryDto>>
{
}