using AutoMapper;
using Core.Context;
using Core.Entities;
using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Core
{
    public class Repository : IRepository
    {
        private readonly IMapper _mapper;        
        private readonly ApplicationDBContext _context;
        private readonly Dictionary<string, IAlgorithms> _algorithmsDiccionary;

        public Repository(IMapper mapper)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
            optionsBuilder.UseSqlite("Filename=MyDatabase.db");
            _context = new ApplicationDBContext(optionsBuilder.Options);
            _mapper = mapper;
            _algorithmsDiccionary = new Dictionary<string, IAlgorithms>
            {
                { AlgorithmsType.FirstFit, new FirstFit() },
                { AlgorithmsType.BestFit, new BestFit() },
                { AlgorithmsType.WorstFit, new WorstFit() },
                { AlgorithmsType.NextFit, new NextFit() }
            };

        }

        public async Task<bool> AddProcessByAlgorithm(ProcessDTO processData, string algorithmType)
        {
            var result = false;
            var blocks = await _context.Blocks.Include(x => x.Processes).ToListAsync();
            var blocksDTO = _mapper.Map<List<BlockDTO>>(blocks);

            var resultAlgorithms = _algorithmsDiccionary[algorithmType].AddProcessToBlock(processData.Size, blocksDTO);

            if (resultAlgorithms.Equals(0))
            {
                return result;
            }

            var blockSelected = blocks.Where(x => x.Order.Equals(resultAlgorithms)).FirstOrDefault();
                       
            var processEntity = _mapper.Map<Process>(processData);

            processEntity.Block = blockSelected;
            processEntity.IdBlock = blockSelected.Id;

            _context.Processes.Add(processEntity);
            await _context.SaveChangesAsync();

            result = true;
            return result;
        }

        public async Task<List<BlockDTO>> GetAllMemoryBlocks()
        {
            var blocks = await _context.Blocks.Include(x => x.Processes).ToListAsync();
            var blocksDTO = _mapper.Map<List<BlockDTO>>(blocks);
            return blocksDTO;
        }

        public async Task<bool> FreeProcess(ProcessDTO processData)
        {
            var result = false;
            try
            {
                var processEntity = _mapper.Map<Process>(processData);
                _context.Processes.Remove(processEntity);
                await _context.SaveChangesAsync();

                result = true;

                return result;
            }
            catch (Exception)
            {
                return result;
            } 
            
        }
    }
}

