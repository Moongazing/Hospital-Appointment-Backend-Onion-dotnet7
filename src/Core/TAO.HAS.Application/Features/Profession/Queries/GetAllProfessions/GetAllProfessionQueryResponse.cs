using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAO.HAS.Application.Features.Profession.Queries.GetAllProfessions
{
    public class GetAllProfessionQueryResponse
    {
        public int TotalProfessionCount { get; set; }
        public object Professions { get; set; }
    }
}
