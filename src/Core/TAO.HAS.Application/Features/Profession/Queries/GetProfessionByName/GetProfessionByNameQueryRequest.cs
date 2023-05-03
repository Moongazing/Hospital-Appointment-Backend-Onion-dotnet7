using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAO.HAS.Application.Features.Profession.Queries.GetProfessionByName
{
    public class GetProfessionByNameQueryRequest:IRequest<GetProfessionByNameQueryResponse>
    {
        public string Name { get; set; }
    }
}
