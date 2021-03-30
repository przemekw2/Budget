using System.Collections.Generic;

namespace API.Entities
{
    public class SpendCategory
    {
        public int Id { get; set; }
        public string SpendName { get; set; }
        public ICollection<BudgetRow> BudgetRows { get; set; }
    }
}