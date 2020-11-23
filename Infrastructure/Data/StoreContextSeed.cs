using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using Core.Entities;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.PhotoOffersCategories.Any())
                {
                    var categoriesData = File.ReadAllText("../Infrastructure/Data/SeedData/PhotoOffersCategories.json");
                    var categories = JsonSerializer.Deserialize<List<PhotoOfferCategory>>(categoriesData);

                    foreach (var category in categories)
                    {
                        context.PhotoOffersCategories.Add(category);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.PhotoOffers.Any())
                {
                    var offersData = File.ReadAllText("../Infrastructure/Data/SeedData/PhotoOffers.json");
                    var offers = JsonSerializer.Deserialize<List<PhotoOffer>>(offersData);

                    foreach (var offer in offers)
                    {
                        context.PhotoOffers.Add(offer);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(e.Message);
            }
        }
    }
}
