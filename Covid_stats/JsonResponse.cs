using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid_stats
{
    public class JsonResponse
    {
        public int cases { get; set; }
        public int recovered { get; set; }
        public int deaths { get; set; }
    }
}
