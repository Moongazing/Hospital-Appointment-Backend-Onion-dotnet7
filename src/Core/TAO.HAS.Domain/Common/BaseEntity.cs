using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAO.HAS.Domain.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; } = true;

        public BaseEntity()
        {
            
        }
        public BaseEntity(Guid id, DateTime createdDate, DateTime updatedDate, bool isActive)
        {
            Id = id;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            IsActive = isActive;
        }

    }
}
