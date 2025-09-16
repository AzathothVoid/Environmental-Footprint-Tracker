using Application.DTOs.FootprintEntry;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.FootprintEntry.Requests.Queries
{
    public class GetFootprintEntryDetailsQuery : IRequest<CustomQueryResponse<FootprintEntryDto>>
    {
        public int Id { get; set; }
    }
}
