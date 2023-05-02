using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.HAS.Application.Repositories;
using TAO.HAS.Domain.Entities;
using TAO.HAS.Persistence.Contexts;

namespace TAO.HAS.Persistence.Repositories
{
    public class ProfessionRepository : GenericRepository<Profession>, IProfessionRepository
    {
        public ProfessionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
