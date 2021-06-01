using Core.Entities;

namespace Core.Specifications
{
    public class SpendWithCategorySpecification : BaseSpecification<Spend>
    {

        public SpendWithCategorySpecification(SpendSpecParams spendParams) : base(
            x => (string.IsNullOrEmpty(spendParams.Search) || x.Description.ToLower().Contains(spendParams.Search)) &&
            (!spendParams.CategoryId.HasValue || x.CategoryId == spendParams.CategoryId)
        )
        {
            AddInclude(s => s.Category);
            AddOrderBy(x => x.CreatedAt);
            ApplyPaging(spendParams.PageSize * (spendParams.PageIndex - 1), spendParams.PageSize);

            if (!string.IsNullOrEmpty(spendParams.Sort))
            {
                switch (spendParams.Sort)
                {
                    case "amountAsc":
                        AddOrderBy(p => p.Amount);
                        break;
                    case "amountDesc":
                        AddOrderByDescending(p => p.Amount);
                        break;
                    default:
                        AddOrderBy(n => n.CreatedAt);
                        break;
                }
            }
        }

        public SpendWithCategorySpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(s => s.Category);
        }

    }
}