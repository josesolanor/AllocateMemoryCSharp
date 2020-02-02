using AutoMapper;
using Core.Context;
using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Core
{
    public class Repository : IRepository
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDBContext _context;

        public Repository(IMapper mapper)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
            optionsBuilder.UseSqlite("Filename=MyDatabase.db");
            _context = new ApplicationDBContext(optionsBuilder.Options);
            _mapper = mapper;

        }

        public Task<bool> AddProcessByAlgorithm(ProcessDTO processData, string algorithmType)
        {
            
        }



        public async Task<List<BlockDTO>> GetAllMemoryBlocks()
        {
            var blocks = await _context.Blocks.Include(x => x.Processes).ToListAsync();
            var blocksDTO = _mapper.Map<List<BlockDTO>>(blocks);
            return blocksDTO;
        }
    }
}
