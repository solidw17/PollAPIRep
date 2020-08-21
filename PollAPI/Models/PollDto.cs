using PollAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollAPI.Models
{
    public class PollDto
    {
        public int Poll_id { get; set; }
        public string Poll_description { get; set; }
        public virtual List<OptionDto> Options { get; set; }
    }
}
