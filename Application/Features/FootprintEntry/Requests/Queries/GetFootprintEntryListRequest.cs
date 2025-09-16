using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Responses;
using Application.DTOs.FootprintEntry;

namespace Application.Features.FootprintEntry.Requests.Queries
{
    public class GetFootprintEntryListRequest : IRequest<CustomQueryResponse<List<FootprintEntryDto>>>
    {

    }
}
