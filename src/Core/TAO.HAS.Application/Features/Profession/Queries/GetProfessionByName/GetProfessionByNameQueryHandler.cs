using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.HAS.Application.Dtos;
using TAO.HAS.Application.Features.Profession.Queries.GetAllProfessions;
using TAO.HAS.Application.Features.Profession.Queries.GetProfessionById;
using TAO.HAS.Application.Features.Profession.Rules;
using TAO.HAS.Application.Repositories;

namespace TAO.HAS.Application.Features.Profession.Queries.GetProfessionByName
{
    public class GetProfessionByNameQueryHandler : IRequestHandler<GetProfessionByNameQueryRequest, GetProfessionByNameQueryResponse>
    {
        private readonly IProfessionRepository _professionRepository;
        private readonly ILogger<GetProfessionByNameQueryHandler> _logger;
        private readonly ProfessionBusinessRules _businessRules;
        private readonly IMapper _mapper;
        public GetProfessionByNameQueryHandler(IProfessionRepository professionRepository, ILogger<GetProfessionByNameQueryHandler> logger, ProfessionBusinessRules businessRules, IMapper mapper)
        {
            _businessRules = businessRules;
            _logger = logger;
            _mapper = mapper;
            _professionRepository = professionRepository;
        }
        public async Task<GetProfessionByNameQueryResponse> Handle(GetProfessionByNameQueryRequest request, CancellationToken cancellationToken)
        {
            await _businessRules.ProfessionNameShouldBeExists(request.Name);

            var professions = await _professionRepository.FindAsync(p => p.Name.ToLower().Contains(request.Name.ToLower()));
            var professionDtos = _mapper.Map<IEnumerable<ProfessionDto>>(professions);

            return new GetProfessionByNameQueryResponse
            {
                Professions = professionDtos
            };

        }
    }
}
