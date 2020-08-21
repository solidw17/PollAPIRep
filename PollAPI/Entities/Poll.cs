using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollAPI.Entities
{
    public class Poll
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Views { get; set; }

        public virtual List<Option> Options { get; set; }
    }
}
