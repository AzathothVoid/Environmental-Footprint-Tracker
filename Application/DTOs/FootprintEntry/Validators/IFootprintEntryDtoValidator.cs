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
    public class IFootprintEntryDtoValidator : AbstractValidator<IFootprintEntryDto>
    {
        public IFootprintEntryDtoValidator()
        {
            RuleFor(x => x.Type)
                  .IsInEnum()
                  .WithMessage("Type is required and must be a valid footprint type.");

            // Amount
            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Amount must be greater than zero.");

            // Unit: always required; for electricity prefer 'kWh'
            RuleFor(x => x.Unit)
                .NotEmpty().WithMessage("Unit is required.")
                .DependentRules(() =>
                {
                    When(x => x.Type == FootprintType.Electricity, () =>
                    {
                        RuleFor(x => x.Unit)
                            .Must(u => string.Equals(u?.Trim(), "kWh", StringComparison.OrdinalIgnoreCase))
                            .WithMessage("For electricity entries the unit should be 'kWh'.");
                    });
                });

            // DetailsJson: must be valid JSON when present; type-specific requirements below
            RuleFor(x => x.DetailsJson)
                .Must(IsNullOrValidJson)
                .WithMessage("DetailsJson must be valid JSON.");

            // Transport requires detailsJson containing "mode"
            RuleFor(x => x.DetailsJson)
                .Must((dto, json) => TransportDetailsHaveMode(dto.Type, json))
                .WithMessage("Transport entries must include a JSON object with a 'mode' property (e.g. { \"mode\": \"car\" }).");

            // Food (example): if details provided, require "foodType" property
            RuleFor(x => x.DetailsJson)
                .Must((dto, json) => FoodDetailsValid(dto.Type, json))
                .WithMessage("Food entries (when details are supplied) should include a 'foodType' property (e.g. { \"foodType\": \"beef\" }).");
        }

        private static bool IsNullOrValidJson(string? json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return true;

            try
            {
                using var _ = JsonDocument.Parse(json);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static bool TransportDetailsHaveMode(FootprintType type, string? json)
        {
            if (type != FootprintType.Transport)
                return true; // not applicable

            // require non-empty JSON and "mode" property
            if (string.IsNullOrWhiteSpace(json))
                return false;

            try
            {
                using var doc = JsonDocument.Parse(json);
                return doc.RootElement.TryGetProperty("mode", out var mode) && mode.ValueKind == JsonValueKind.String && !string.IsNullOrWhiteSpace(mode.GetString());
            }
            catch
            {
                return false;
            }
        }

        private static bool FoodDetailsValid(FootprintType type, string? json)
        {
            if (type != FootprintType.Food)
                return true;

            if (string.IsNullOrWhiteSpace(json))
                return true; // food details optional — change to false to make mandatory

            try
            {
                using var doc = JsonDocument.Parse(json);
                // accept if it has "foodType" as a string
                if (doc.RootElement.TryGetProperty("foodType", out var ft) && ft.ValueKind == JsonValueKind.String)
                    return !string.IsNullOrWhiteSpace(ft.GetString());
                // or accept other acceptable keys if you prefer
                return true; // if you want to require foodType, return false here instead
            }
            catch
            {
                return false;
            }
        }
    }
}
