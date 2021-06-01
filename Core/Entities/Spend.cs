using System;

namespace Core.Entities
{
    public class Spend : BaseEntity
    {
        public DateTime? CreatedAt { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }

}