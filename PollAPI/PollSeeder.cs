using PollAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollAPI
{
    public class PollSeeder
    {
        private readonly PollContext _pollContext;

        public PollSeeder(PollContext pollContext)
        {
            _pollContext = pollContext;
        }

        public void Seed()
        {
            if (_pollContext.Database.CanConnect())
            {
                if (!_pollContext.Polls.Any())
                {
                    InsertSampleData();
                }
            }
        }

        private void InsertSampleData()
        {
            var polls = new List<Poll>
            {
                new Poll
                {
                    Description = "Qual o seu animal esquisito preferido da Austrália?",
                    Options = new List<Option>
                    {
                        new Option
                        {
                            Description = "Ornitorrinco",
                            Qty = 0
                        },
                        new Option
                        {
                            Description = "Kiwi",
                            Qty = 0
                        },
                        new Option
                        {
                            Description = "Casuar",
                            Qty = 0
                        }
                    }
                },
                new Poll
                {
                    Description = "Qual o seu filme Trash preferido?",
                    Options = new List<Option>
                    {
                        new Option
                        {
                            Description = "Ataque dos vermes malditos",
                            Qty = 0
                        },
                        new Option
                        {
                            Description = "Ataque dos tomates assassinos",
                            Qty = 0
                        },
                        new Option
                        {
                            Description = "Gremlins",
                            Qty = 0
                        }
                    }
                },
                new Poll
                {
                    Description = "Qual seu animal de estimação preferido?",
                    Options = new List<Option>
                    {
                        new Option
                        {
                            Description = "Cachorro",
                            Qty = 0
                        },
                        new Option
                        {
                            Description = "Gato",
                            Qty = 0
                        },
                        new Option
                        {
                            Description = "Outros",
                            Qty = 0
                        }
                    }
                },
            };

            _pollContext.AddRange(polls);
            _pollContext.SaveChanges();
        }
    }
}
