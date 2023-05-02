 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.HAS.Domain.Common;

namespace TAO.HAS.Domain.Entities
{
    public class Profession:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Profession()
        {
            
        }
        public Profession(Guid id, DateTime createdDate, DateTime updatedDate, string name, string description)
        {
            Id = id;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            Name = name;
            Description = description;
        }
    }

}
