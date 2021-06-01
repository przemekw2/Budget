using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Core.Interfaces;
using Core.Specifications;
using API.Dtos;
using AutoMapper;
using API.Errors;
using Microsoft.AspNetCore.Http;
using API.Helpers;

namespace API.Controllers
{
    public class SpendsController : BaseApiController
    {

        private readonly IGenericRepository<Spend> _spendRepo;
        private readonly IGenericRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;

        public SpendsController(IGenericRepository<Spend> spendRepo, IGenericRepository<Category> categoryRepo, IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepo = categoryRepo;
            _spendRepo = spendRepo;

            //_repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<SpendResourceDto>>> GetSpends([FromQuery]SpendSpecParams spendParams)
        {

            var spec = new SpendWithCategorySpecification(spendParams);
            var countSpec = new SpendsWithFiltersForCountSpecification(spendParams);

            var totalItems = await _spendRepo.CountAsync(countSpec);

            var spends = await _spendRepo.ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<SpendResourceDto>>(spends);

            return Ok(new Pagination<SpendResourceDto>(spendParams.PageIndex, 
                spendParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SpendResourceDto>> GetSpend(int id)
        {
            var spec = new SpendWithCategorySpecification(id);
            var spend = await _spendRepo.GetEntityWithSpec(spec);

            if (spend == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Spend, SpendResourceDto>(spend);
        }

        [HttpGet("categiories")]
        public async Task<ActionResult<IReadOnlyList<Category>>> GetCategories()
        {
            return Ok(await _categoryRepo.ListAllAsync());
        }
    }
}