using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAO.HAS.Infrastructure.ElasticSearch.Models
{
    public class ElasticSearchGetModel<T>
    {
        public string ElasticId { get; set; }
        public T Item { get; set; }
    }
}
