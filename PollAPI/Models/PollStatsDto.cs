using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollAPI.Models
{
    public class PollStatsDto
    {
        public int Views { get; set; }

        public virtual List<OptionStatsDto> Votes { get; set; }
    }
}
