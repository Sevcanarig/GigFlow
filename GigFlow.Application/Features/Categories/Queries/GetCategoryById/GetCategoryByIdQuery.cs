using GigFlow.Application.Features.Categories.Dtos;
using MediatR;

namespace GigFlow.Application.Features.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQuery : IRequest<CategoryDto>
{
    public Guid Id { get; set; }
}