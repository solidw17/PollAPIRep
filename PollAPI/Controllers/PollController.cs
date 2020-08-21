using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PollAPI.Entities;
using PollAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PollAPI.Controllers
{
    [Route("poll")]
    [ApiController]
    public class PollController : ControllerBase
    {
        private readonly PollContext _pollContext;
        private readonly IMapper _mapper;

        public PollController(PollContext meetupContext, IMapper mapper)
        {
            _pollContext = meetupContext;
            _mapper = mapper;
        }

        // GET: poll
        [HttpGet]
        public ActionResult<List<PollDto>> Get()
        {
            var polls = _pollContext.Polls.Include(p => p.Options).ToList(); // .Include(m => m.Options)
            var pollDtos = _mapper.Map<List<PollDto>>(polls);
            return Ok(pollDtos);
        }

        // GET: poll/:id
        [HttpGet("{id}")]
        public ActionResult<PollDto> Get(int id)
        {
            var poll = _pollContext.Polls.Include(p => p.Options).FirstOrDefault(p => p.Id == id);

            if(poll == null)
            {
                return NotFound();
            }
            poll.Views++;
            _pollContext.SaveChanges();
            var pollDto = _mapper.Map<PollDto>(poll);
            return Ok(pollDto);
        }

        // POST: poll/
        [HttpPost]
        public ActionResult Post([FromBody]PollPostDto model)
        {

            var poll = _mapper.Map<Poll>(model);
            poll.Views = 0;
            foreach(Option option in poll.Options)
            {
                option.Qty = 0;
            }
            _pollContext.Polls.Add(poll);
            _pollContext.SaveChanges();

            var pollId = _mapper.Map<PollIdDto>(poll);

            return Created("poll/" + poll.Id, pollId);
        }
    }
}
