﻿using FluentValidation;
using NLayer.Core.DTOs;

namespace NLayer.Service.Validations;

public class ProductDtoValidatior:AbstractValidator<ProductDto>
{
    public ProductDtoValidatior()
    {
        RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{ProperyName} is required");
        RuleFor(x => x.Price).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be grater 0");
        RuleFor(x => x.Stock).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be grater 0");
        RuleFor(x => x.CategoryId).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be grater 0");
    }
}