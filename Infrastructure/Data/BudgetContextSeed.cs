using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class BudgetContextSeed
    {
        public static async Task SeedAsync(BudgetContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if(!context.Categories.Any())
                {
                    var categoriesData = File.ReadAllText("../Infrastructure/Data/SeedData/CategoriesList.json");
                    var categories = JsonSerializer.Deserialize<List<Category>>(categoriesData);

                    foreach(var item in categories)
                    {
                        context.Categories.Add(item);
                    }

                    await context.SaveChangesAsync();

                }

                if(!context.Spends.Any())
                {
                    var spendData = File.ReadAllText("../Infrastructure/Data/SeedData/SpendList.json");
                    var spends = JsonSerializer.Deserialize<List<Spend>>(spendData);

                    foreach(var item in spends)
                    {
                        context.Spends.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<BudgetContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}