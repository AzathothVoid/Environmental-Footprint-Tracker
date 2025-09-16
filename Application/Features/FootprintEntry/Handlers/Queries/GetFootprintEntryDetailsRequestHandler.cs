using Application.Contracts.Persistence;
using Application.DTOs.FootprintEntry;
using Application.DTOs.Snippet;
using Application.Features.FootprintEntry.Requests.Queries;
using Application.Features.Snippets.Requests.Queries;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Snippets.Handlers.Queries
{
    public class GetFootprintEntryDetailsRequestHandler : IRequestHandler<GetFootprintEntryDetailsQuery, CustomQueryResponse<FootprintEntryDto>>
    {
        private readonly IFootprintEntryRepository _footprintEntryRepository;
        private readonly IMapper _mapper;

        public GetFootprintEntryDetailsRequestHandler(IFootprintEntryRepository footprintEntryRepository, IMapper mapper)
        {
            _footprintEntryRepository = footprintEntryRepository;
            _mapper = mapper;
        }

        public async Task<CustomQueryResponse<FootprintEntryDto>> Handle(GetFootprintEntryDetailsQuery request, CancellationToken cancellationToken)
        {
            var response = new CustomQueryResponse<FootprintEntryDto>();
            var footprintEntryDetail = await _footprintEntryRepository.GetAsync(request.Id);

            if (footprintEntryDetail == null)
            {
                response.Success = false;
                response.Message = "Footprint Entry not found";
                return response;
            }

            response.Success = true;
            response.Message = "GET Successful";
            response.Data = _mapper.Map<FootprintEntryDto>(footprintEntryDetail);

            return response;
        }
    }
}
