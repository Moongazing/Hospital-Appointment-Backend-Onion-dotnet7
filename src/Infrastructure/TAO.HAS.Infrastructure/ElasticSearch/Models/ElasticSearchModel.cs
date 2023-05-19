using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAO.HAS.Infrastructure.ElasticSearch.Models
{
    public class ElasticSearchModel
    {
        public Id ElasticId { get; set; }
        public string IndexName { get; set; }
    }
}
