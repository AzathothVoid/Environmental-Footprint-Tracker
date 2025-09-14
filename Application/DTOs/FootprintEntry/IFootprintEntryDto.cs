using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.FootprintEntry
{
    public interface IFootprintEntryDto
    {
        public FootprintType Type { get; set; }
        public decimal Amount { get; set; }
        public string Unit { get; set; }
        public string? DetailsJson { get; set; }
    }
}
