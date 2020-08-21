using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PollAPI.Entities;
using PollAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollAPI.Controllers
{
    // poll/:id
    [Route("poll/{pollId}")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        private readonly PollContext _pollContext;
        private readonly IMapper _mapper;

        public OptionController(PollContext meetupContext, IMapper mapper)
        {
            _pollContext = meetupContext;
            _mapper = mapper;
        }

        // POST: poll/:id/vote
        [HttpPost("vote")]
        public ActionResult Post([FromBody]OptionIdDto optionIdDto)
        {
            int pollId = int.Parse((string)this.RouteData.Values["pollId"]);
            var poll = _pollContext.Polls.FirstOrDefault(o => o.Id == pollId);

            var option = _pollContext.Options.FirstOrDefault(o => o.Id == optionIdDto.Option_id && o.PollId == pollId);

            if(option == null)
            {
                return NotFound();
            }

            option.Qty++;
            _pollContext.SaveChanges();
            return NoContent();
        }

        // GET: poll/:id/stats
        [HttpGet("stats")]
        public ActionResult Get(int pollId)
        {
            var poll = _pollContext.Polls.Include(p => p.Options).FirstOrDefault(o => o.Id == pollId);

            if(poll == null)
            {
                return NotFound();
            }

            var pollStats = _mapper.Map<PollStatsDto>(poll);
            return Ok(pollStats);
        }
    }
}
