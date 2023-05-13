using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.HAS.Application.Features.Profession.Rules;
using TAO.HAS.Application.Repositories;

namespace TAO.HAS.Application.Features.Profession.Commands.CreateProfession
{

    public class CreateProfessionCommandHandler : IRequestHandler<CreateProfessionCommandRequest, CreateProfessionCommandResponse>
    {
        private readonly IProfessionRepository _professionRepository;
        private readonly IMapper _mapper;
        private readonly ProfessionBusinessRules _professionBusinessRules;
        private readonly ILogger<CreateProfessionCommandHandler> _logger;
        public CreateProfessionCommandHandler(IProfessionRepository professionRepository, IMapper mapper, ProfessionBusinessRules professionBusinessRules, ILogger<CreateProfessionCommandHandler> logger)
        {
            _mapper = mapper;
            _professionRepository = professionRepository;
            _professionBusinessRules = professionBusinessRules;
            _logger = logger;
        }
        public async Task<CreateProfessionCommandResponse> Handle(CreateProfessionCommandRequest request, CancellationToken cancellationToken)
        {
            await _professionBusinessRules.ProfessionNameCanNotBeDuplicatedWhenInsertedOrUpdated(request.Name);

            var profession = _mapper.Map<Domain.Entities.Profession>(request);

            _professionRepository.Add(profession);
            
            await _professionRepository.SaveChangesAsync();

            _logger.LogInformation($"The profession added, name:{request.Name}  description:{request.Description}");

            CreateProfessionCommandResponse response = _mapper.Map<CreateProfessionCommandResponse>(profession);

            return response;

            
        }
    }
}
