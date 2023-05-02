using AutoMapper;
using MediatR;
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
        public CreateProfessionCommandHandler(IProfessionRepository professionRepository, IMapper mapper, ProfessionBusinessRules professionBusinessRules)
        {
            _mapper = mapper;
            _professionRepository = professionRepository;
            _professionBusinessRules = professionBusinessRules;
        }
        public async Task<CreateProfessionCommandResponse> Handle(CreateProfessionCommandRequest request, CancellationToken cancellationToken)
        {
            await _professionBusinessRules.ProfessionNameCanNotBeDuplicatedWhenInserted(request.Name);

            var profession = _mapper.Map<Domain.Entities.Profession>(request);
            _professionRepository.Add(profession);
            
            await _professionRepository.SaveChangesAsync();

            CreateProfessionCommandResponse response = _mapper.Map<CreateProfessionCommandResponse>(profession);
            return response;

            
        }
    }
}
