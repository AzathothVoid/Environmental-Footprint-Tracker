using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.DTOs.FootprintEntry.Validators
{
    public class UpdateFootprintEntryDtoValidator : AbstractValidator<UpdateFootprintEntryDto>
    {
        private static readonly Regex RegionRegex = new Regex(@"^[A-Za-z]{2,3}(?:-[A-Za-z0-9]{1,3})?$", RegexOptions.Compiled);
        public UpdateFootprintEntryDtoValidator()
        {
            Include(new IFootprintEntryDtoValidator());
            RuleFor(x => x.RegionCode)
            .Cascade(CascadeMode.Stop)
            .Must(code => string.IsNullOrWhiteSpace(code) || RegionRegex.IsMatch(code!.Trim()))
            .WithMessage("RegionCode must be empty or an ISO-like code (e.g. 'US', 'GB', 'USA' or 'US-CA').");
        }
    }
}
