using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAO.HAS.Infrastructure.ElasticSearch.Models
{
    public class ElasticSeachInsertManyModel: ElasticSearchModel
    {
        public object[] Items { get; set; }
    }
}
