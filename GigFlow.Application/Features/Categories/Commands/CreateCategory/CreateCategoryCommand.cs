using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigFlow.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
