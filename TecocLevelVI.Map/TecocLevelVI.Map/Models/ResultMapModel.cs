using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecocLevelVI.Map.Models
{
    public class ResultMapModel
    {
        public string formatted_address { get; set; }
        public GeometryModel geometry { get; set; }
    }
}
