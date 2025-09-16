using Application.Contracts.Persistence;
using Application.DTOs.FootprintEntry;
using Application.Features.FootprintEntry.Requests.Queries;
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
    public class GetFootprintEntryListQueryHandler : IRequestHandler<GetFootprintEntryListQuery, CustomQueryResponse<List<FootprintEntryDto>>>
    {
        private readonly IFootprintEntryRepository _footprintEntryRepository;
        private readonly IMapper _mapper;

        public GetFootprintEntryListQueryHandler(IFootprintEntryRepository footprintEntryRepository, IMapper mapper)
        {
            _footprintEntryRepository = footprintEntryRepository;
            _mapper = mapper;
        }


        public async Task<CustomQueryResponse<List<FootprintEntryDto>>> Handle(GetFootprintEntryListQuery request, CancellationToken cancellationToken)
        {
            var response = new CustomQueryResponse<List<FootprintEntryDto>>();
            var footprintEntryDetail = await _footprintEntryRepository.GetAllAsync();

            if (footprintEntryDetail == null)
            {
                response.Success = false;
                response.Message = "Snippets not found";
                return response;
            }
            
            response.Success = true;
            response.Message = "GET Successful";
            response.Data = _mapper.Map<List<FootprintEntryDto>>(footprintEntryDetail);

            return response;
        }
    }
}
