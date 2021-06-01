using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IBudgetRepository
    {
        Task<Spend> GetSpendByIdAsync(int id);
        Task<IReadOnlyList<Spend>> GetSpendsAsync();
        Task<IReadOnlyList<Category>> GetCategoriesAsync();
    }
}