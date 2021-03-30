using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpendCategoriesController : ControllerBase
    {
        private readonly BudgetContext _context;
        public SpendCategoriesController(BudgetContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SpendCategory>>> GetSpendCategories()
        {
            var categories = await _context.SpendCategories.ToListAsync();
            return Ok(categories);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<SpendCategory>> GetSpendCategory(int id)
        {
            return await _context.SpendCategories.FindAsync(id);
        }
    }
}