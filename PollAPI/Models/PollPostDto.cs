using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollAPI.Models
{
    public class PollPostDto
    {
        public string Poll_description { get; set; }
        public int Views { get; set; }

        public virtual List<OptionPostDto> Options { get; set; }
    }
}
