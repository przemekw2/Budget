using System;
using Core.Entities;

namespace API.Dtos
{
    public class SpendResourceDto
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }

        public string Category { get; set; }
    }
}