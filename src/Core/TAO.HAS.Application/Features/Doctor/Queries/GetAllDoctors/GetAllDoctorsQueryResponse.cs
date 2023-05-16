using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.HAS.Application.Dtos;

namespace TAO.HAS.Application.Features.Doctor.Queries.GetAllDoctors
{
    public class GetAllDoctorsQueryResponse
    {
        public int TotalDoctorCount { get; set; }
        public List<DoctorDto> Doctors { get; set; }
    }
}
