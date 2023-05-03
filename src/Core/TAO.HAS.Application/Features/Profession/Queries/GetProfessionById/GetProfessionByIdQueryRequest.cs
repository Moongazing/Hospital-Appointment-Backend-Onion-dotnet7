using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAO.HAS.Application.Features.Profession.Queries.GetProfessionById
{
    public class GetProfessionByIdQueryRequest:IRequest<GetProfessionByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
