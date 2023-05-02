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

namespace TAO.HAS.Application.Features.Profession.Commands.UpdateProfession
{
    public class UpdateProfessionCommandHandler : IRequestHandler<UpdateProfessionCommandRequest, UpdateProfessionCommandResponse>
    {
        private readonly IProfessionRepository _professionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateProfessionCommandHandler> _logger;
        private readonly ProfessionBusinessRules _professionBusinessRules;
        public UpdateProfessionCommandHandler(IProfessionRepository professionRepository, IMapper mapper, ILogger<UpdateProfessionCommandHandler> logger, ProfessionBusinessRules professionBusinessRules)
        {
            _professionRepository = professionRepository;
            _logger = logger;
            _mapper = mapper;
            _professionBusinessRules = professionBusinessRules;
        }
        public async Task<UpdateProfessionCommandResponse> Handle(UpdateProfessionCommandRequest request, CancellationToken cancellationToken)
        {
            await _professionBusinessRules.ProfessionShouldBeExistsWhenDeletedOrUpdated(request.Id);

            await _professionBusinessRules.ProfessionNameCanNotBeDuplicatedWhenInsertedOrUpdated(request.Name);

            var profession = await _professionRepository.GetByIdAsync(request.Id);

            var mapperProfession = _mapper.Map(request, profession);

            _professionRepository.Update(mapperProfession);

            await _professionRepository.SaveChangesAsync();

            _logger.LogInformation($"This {request.Id} owner profession has been updated, updated name:{request.Name} updated description:{request.Description}");

            return new UpdateProfessionCommandResponse();

        }
    }
}
