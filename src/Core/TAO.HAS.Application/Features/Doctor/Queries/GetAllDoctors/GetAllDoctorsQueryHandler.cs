using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TAO.HAS.Application.Dtos;
using TAO.HAS.Application.Features.Profession.Queries.GetAllProfessions;
using TAO.HAS.Application.Repositories;
using TAO.HAS.Domain.Entities;

namespace TAO.HAS.Application.Features.Doctor.Queries.GetAllDoctors
{
    public class GetAllDoctorsQueryHandler : IRequestHandler<GetAllDoctorsQueryRequest, GetAllDoctorsQueryResponse>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly ILogger<GetAllDoctorsQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetAllDoctorsQueryHandler(IDoctorRepository doctorRepository, ILogger<GetAllDoctorsQueryHandler> logger, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _logger = logger;
            _mapper = mapper;
        }
       
       public async Task<GetAllDoctorsQueryResponse> Handle(GetAllDoctorsQueryRequest request, CancellationToken cancellationToken)
        {
            var totalDoctorsCount = await _doctorRepository.GetAllAsync().CountAsync();

            var includeProperties = new Expression<Func<Domain.Entities.Doctor, object>>[]
            {
                d => d.Profession,
                d => d.Department
            };

            var doctors = await _doctorRepository.GetAllAsync(includeProperties).ToListAsync();

            var doctorDtos = _mapper.Map<List<DoctorDto>>(doctors)
                .Select(d => new DoctorDto
                {
                    DoctorDepartment = d.DoctorDepartment,
                    DoctorProfession = d.DoctorProfession,
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    NationalIdentity = d.NationalIdentity,
                    Email = d.Email
                })
                .ToList();

            return new GetAllDoctorsQueryResponse
            {
                Doctors = doctorDtos,
                TotalDoctorCount = totalDoctorsCount
            };
        }
    }
}
