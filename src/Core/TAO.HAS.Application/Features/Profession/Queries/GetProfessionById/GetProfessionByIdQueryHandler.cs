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

namespace TAO.HAS.Application.Features.Profession.Queries.GetProfessionById
{
    public class GetProfessionByIdQueryHandler : IRequestHandler<GetProfessionByIdQueryRequest, GetProfessionByIdQueryResponse>
    {
        private readonly IProfessionRepository _professionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetProfessionByIdQueryHandler> _logger;
        private readonly ProfessionBusinessRules _professionBusinessRules;

        public GetProfessionByIdQueryHandler(IProfessionRepository professionRepository, IMapper mapper, ILogger<GetProfessionByIdQueryHandler> logger, ProfessionBusinessRules professionBusinessRules)
        {
            _logger = logger;
            _professionBusinessRules = professionBusinessRules;
            _mapper = mapper;
            _professionRepository = professionRepository;
        }
        public async Task<GetProfessionByIdQueryResponse> Handle(GetProfessionByIdQueryRequest request, CancellationToken cancellationToken)
        {
            await _professionBusinessRules.ProfessionShouldBeExistsWhenDeletedOrUpdated(request.Id);

            Domain.Entities.Profession profession = await _professionRepository.GetByIdAsync(request.Id);

            var mapperProfession = _mapper.Map<GetProfessionByIdQueryResponse>(profession);

            return mapperProfession;


        }
    }

}

