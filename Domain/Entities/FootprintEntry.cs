using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FootprintEntry : AuditableBaseEntity
    {
        public string? UserId { get; set; }            
        public FootprintType Type { get; set; }
        public DateTimeOffset Date { get; set; }       
        public decimal Amount { get; set; }            
        public string Unit { get; set; } = "";         
        public decimal EmissionKgCO2e { get; set; }   
        public string? RegionCode { get; set; }        
        public string? DetailsJson { get; set; }       
    }

    public enum FootprintType { Electricity, Transport, Food, Waste }
}
