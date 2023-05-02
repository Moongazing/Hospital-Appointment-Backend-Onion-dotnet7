using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.HAS.Application.Features.Profession.Commands.CreateProfession;
using TAO.HAS.Application.Features.Profession.Rules;
using TAO.HAS.Application.Repositories;

namespace TAO.HAS.Application.Features.Profession.Commands.DeleteProfession
{
    public class DeleteProfessionCommandHandler : IRequestHandler<DeleteProfessionCommandRequest, DeleteProfessionCommandResponse>
    {
        private readonly IProfessionRepository _professionRepository;
        private readonly ProfessionBusinessRules _professionBusinessRules;
        private readonly ILogger<DeleteProfessionCommandHandler> _logger;
        private readonly IMapper _mapper;

        public DeleteProfessionCommandHandler(IProfessionRepository professionRepository, ProfessionBusinessRules professionBusinessRules,ILogger<DeleteProfessionCommandHandler> logger, IMapper mapper)
        {
            _professionBusinessRules = professionBusinessRules;
            _professionRepository = professionRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<DeleteProfessionCommandResponse> Handle(DeleteProfessionCommandRequest request, CancellationToken cancellationToken)
        {
            await _professionBusinessRules.ProfessionShouldBeExistsWhenDeletedAndUpdated(request.Id);

            var profession = await _professionRepository.GetByIdAsync(request.Id);

            _professionRepository.Delete(profession);

            await _professionRepository.SaveChangesAsync();

            _logger.LogInformation($"This {request.Id} owner profession has been deleted.");

            DeleteProfessionCommandResponse response = _mapper.Map<DeleteProfessionCommandResponse>(profession);

            return response;

        }
    }
}
