using Core.Entities;

namespace Core.Specifications
{
    public class SpendsWithFiltersForCountSpecification : BaseSpecification<Spend>
    {
        public SpendsWithFiltersForCountSpecification(SpendSpecParams spendParams) : base(
            x => 
            (string.IsNullOrEmpty(spendParams.Search) || x.Description.ToLower().Contains(spendParams.Search)) &&
            (!spendParams.CategoryId.HasValue || x.CategoryId == spendParams.CategoryId)
        )
        {
            
        }
    }
}