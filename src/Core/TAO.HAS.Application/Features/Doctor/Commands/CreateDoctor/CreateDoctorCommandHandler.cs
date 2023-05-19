using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.HAS.Application.Features.Doctor.Rules;
using TAO.HAS.Application.Features.Profession.Commands.CreateProfession;
using TAO.HAS.Application.Repositories;
using TAO.HAS.Domain.Entities;

namespace TAO.HAS.Application.Features.Doctor.Commands.CreateDoctor
{
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommandRequest, CreateDoctorCommandResponse>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly ILogger<CreateDoctorCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly DoctorBusinessRules _doctorBusinessRules;

        public CreateDoctorCommandHandler(IDoctorRepository doctorRepository, ILogger<CreateDoctorCommandHandler> logger, IMapper mapper, DoctorBusinessRules doctorBusinessRules)
        {
            _doctorBusinessRules = doctorBusinessRules;
            _mapper = mapper;
            _doctorRepository = doctorRepository;
            _logger = logger;
        }
        public async Task<CreateDoctorCommandResponse> Handle(CreateDoctorCommandRequest request, CancellationToken cancellationToken)
        {
            await _doctorBusinessRules.NationalIdentityCannotDuplicatedWhenInsertedOrUpdated(request.NationalIdentity);
            await _doctorBusinessRules.EmailCannotDuplicateWhenInsertedOrUpdated(request.Email);
            await _doctorBusinessRules.PhoneNumberCannotDuplicateWhenInsertedOrUpdated(request.Phone);
             //_doctorBusinessRules.DateOfBirthShouldBeBiggerToday(request.DateOfBirth);
             //_doctorBusinessRules.DoctorAgeShoulBeBiggerThanTwentyTwo(request.DateOfBirth);

            var doctor = _mapper.Map<Domain.Entities.Doctor>(request);

            _doctorRepository.Add(doctor);

            await _doctorRepository.SaveChangesAsync();

            _logger.LogInformation($"The doctor added, national identity:{request.NationalIdentity} name:{request.FirstName +" "+ request.LastName}, phone number:{request.Phone}, email:{request.Email} , date of birth: {request.DateOfBirth}");

            CreateDoctorCommandResponse response = _mapper.Map<CreateDoctorCommandResponse>(doctor);

            return response;



        }
    }
}
