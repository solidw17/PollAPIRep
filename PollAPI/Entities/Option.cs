using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollAPI.Entities
{
    public class Option
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }

        public virtual Poll Poll { get; set; }
        public int PollId { get; set; }
    }
}
