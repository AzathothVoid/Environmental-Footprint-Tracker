using Application.DTOs.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.FootprintEntry
{
    public class FootprintEntryDto : BaseDTO, IFootprintEntryDto
    {
        public FootprintType Type { get; set; }
        public DateTimeOffset Date { get; set; }
        public decimal Amount { get; set; }
        public string Unit { get; set; } = "";
        public decimal EmissionKgCO2e { get; set; }
        public string? RegionCode { get; set; }
        public string? DetailsJson { get; set; }
    }
}
