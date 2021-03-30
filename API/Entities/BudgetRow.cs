using System;

namespace API.Entities
{
    public class BudgetRow
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }

        public int SpendCategoryId { get; set; }
        public SpendCategory SpendCategory { get; set; }

    }

}