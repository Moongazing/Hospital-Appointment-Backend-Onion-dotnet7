using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.HAS.Application.Dtos;
using TAO.HAS.Application.Repositories;
using TAO.HAS.Domain.Entities;

namespace TAO.HAS.Application.Features.Profession.Queries.GetAllProfessions
{
    public class GetAllProfessionQueryHandler : IRequestHandler<GetAllProfessionQueryRequest, GetAllProfessionQueryResponse>
    {
        private readonly IProfessionRepository _professionRepository;
        private readonly ILogger<GetAllProfessionQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetAllProfessionQueryHandler(IProfessionRepository professionRepository, IMapper mapper, ILogger<GetAllProfessionQueryHandler> logger)
        {
            _professionRepository = professionRepository;
            _logger = logger;
            _mapper = mapper;
        }


        public async Task<GetAllProfessionQueryResponse> Handle(GetAllProfessionQueryRequest request, CancellationToken cancellationToken)
        {
            var totalProfessionCount = _professionRepository.GetAll().Count();

            var professions = _professionRepository.GetAll()
                .Skip(request.Page * request.Size)
                .Take(request.Size)
                .ProjectTo<ProfessionDto>(_mapper.ConfigurationProvider)
                .ToList();

            return await Task.FromResult(new GetAllProfessionQueryResponse
            {
                Professions = professions,
                TotalProfessionCount = totalProfessionCount
            });

        }
    }
}
    

