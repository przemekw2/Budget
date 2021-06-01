using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly BudgetContext _context;

        public BudgetRepository(BudgetContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<IReadOnlyList<Spend>> GetSpendsAsync()
        {
            return await _context.Spends
            .Include(s => s.Category)
            .ToListAsync();
        }

        public async Task<Spend> GetSpendByIdAsync(int id)
        {
            return await _context.Spends
            .Include(s => s.Category)
            .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}