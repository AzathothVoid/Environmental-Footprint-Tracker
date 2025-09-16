using Application.DTOs.FootprintEntry;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.FootprintEntry.Requests.Queries
{
    public class GetFootprintEntryDetailsRequest : IRequest<CustomQueryResponse<FootprintEntryDto>>
    {
        public int id { get; set; }
    }
}
