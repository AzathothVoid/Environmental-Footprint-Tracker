using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.DTOs.FootprintEntry.Validators
{
    public class CreateFootprintEntryDtoValidator : AbstractValidator<CreateFootprintEntryDto>
    {
        public CreateFootprintEntryDtoValidator()
        {
            Include(new IFootprintEntryDtoValidator);
        }
    }
}
