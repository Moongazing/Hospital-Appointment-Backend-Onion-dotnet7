using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.HAS.Application.Dtos;
using TAO.HAS.Application.Features.Profession.Commands.CreateProfession;
using TAO.HAS.Application.Features.Profession.Commands.DeleteProfession;
using TAO.HAS.Application.Features.Profession.Commands.UpdateProfession;
using TAO.HAS.Application.Features.Profession.Queries.GetProfessionByCreatedDate;
using TAO.HAS.Application.Features.Profession.Queries.GetProfessionById;
using TAO.HAS.Application.Features.Profession.Queries.GetProfessionByName;
using TAO.HAS.Domain.Entities;

namespace TAO.HAS.Application.Features.Profession.Mapping
{
    public class ProfessionProfile : Profile
    {
        public ProfessionProfile()
        {
            
            CreateMap<CreateProfessionCommandRequest, Domain.Entities.Profession>().ReverseMap();
            CreateMap<CreateProfessionCommandResponse, Domain.Entities.Profession>().ReverseMap();

            CreateMap<DeleteProfessionCommandRequest, Domain.Entities.Profession>().ReverseMap();
            CreateMap<DeleteProfessionCommandResponse, Domain.Entities.Profession>().ReverseMap();

            CreateMap<UpdateProfessionCommandRequest, Domain.Entities.Profession>().ReverseMap();
            CreateMap<UpdateProfessionCommandResponse, Domain.Entities.Profession>().ReverseMap();

            CreateMap<UpdateProfessionCommandRequest, Domain.Entities.Profession>().ReverseMap();
            CreateMap<UpdateProfessionCommandResponse, Domain.Entities.Profession>().ReverseMap();

            CreateMap<ProfessionDto, Domain.Entities.Profession>().ReverseMap();

            CreateMap<GetProfessionByIdQueryResponse, Domain.Entities.Profession>().ReverseMap();

            
            CreateMap<GetProfessionByNameQueryResponse, Domain.Entities.Profession>().ReverseMap();

        }
    }
}
