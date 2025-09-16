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
    public class GetFootprintEntryListQueryHandler : IRequestHandler<GetSnippetListQuery, CustomQueryResponse<List<SnippetDto>>>
    {
        private readonly IFootprintEntryRepository _footprintEntryRepository;
        private readonly IMapper _mapper;

        public GetFootprintEntryListQueryHandler(IFootprintEntryRepository footprintEntryRepository, IMapper mapper)
        {
            _footprintEntryRepository = footprintEntryRepository;
            _mapper = mapper;
        }


        public async Task<CustomQueryResponse<List<SnippetDto>>> Handle(GetSnippetListQuery request, CancellationToken cancellationToken)
        {
            var response = new CustomQueryResponse<List<SnippetDto>>();
            var snippetDetail = await _snippetRepository.GetAllAsync();

            if (snippetDetail == null)
            {
                response.Success = false;
                response.Message = "Snippets not found";
                return response;
            }
            
            response.Success = true;
            response.Message = "GET Successful";
            response.Data = _mapper.Map<List<SnippetDto>>(snippetDetail);

            return response;
        }
    }
}
