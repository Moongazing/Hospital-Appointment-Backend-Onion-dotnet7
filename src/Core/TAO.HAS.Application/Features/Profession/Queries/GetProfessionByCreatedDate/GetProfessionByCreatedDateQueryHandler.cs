using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.HAS.Application.Dtos;
using TAO.HAS.Application.Features.Profession.Rules;
using TAO.HAS.Application.Repositories;

namespace TAO.HAS.Application.Features.Profession.Queries.GetProfessionByCreatedDate
{
    public class GetProfessionByCreatedDateQueryHandler : IRequestHandler<GetProfessionByCreatedDateQueryRequest, GetProfessionByCreatedDateQueryResponse>
    {

        private readonly IProfessionRepository _professionRepository;
        private readonly ILogger<GetProfessionByCreatedDateQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ProfessionBusinessRules _professionBusinessRules;

        public GetProfessionByCreatedDateQueryHandler(IProfessionRepository professionRepository, ILogger<GetProfessionByCreatedDateQueryHandler> logger, IMapper mapper, ProfessionBusinessRules professionBusinessRules)
        {
            _professionBusinessRules = professionBusinessRules;
            _professionRepository = professionRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<GetProfessionByCreatedDateQueryResponse> Handle(GetProfessionByCreatedDateQueryRequest request, CancellationToken cancellationToken)
        {
            var professions = await _professionRepository.FindAsync(p => p.CreatedDate.ToString("yyyy/MM/dd") == request.CreatedDate.ToString("yyyy/MM/dd"));
            var response = new GetProfessionByCreatedDateQueryResponse();
            response.Professions = _mapper.Map<List<ProfessionDto>>(professions);
            return response;

        }
    }
}
