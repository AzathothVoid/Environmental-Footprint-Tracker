using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.FootprintEntry.Validators
{
    public class UpdateFootprintEntryDtoValidator : AbstractValidator<UpdateFootprintEntryDto>
    {
        public UpdateFootprintEntryDtoValidator()
        {
            Include(new IFootprintEntryDtoValidator());
        }
    }
}
