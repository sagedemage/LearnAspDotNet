using Microsoft.EntityFrameworkCore;

// Issue is right here
using Microsoft.Extensions.DependencyInjection;
using LearnAspDotNet.Data;
using System;
using System.Linq;

namespace LearnAspDotNet.Models
{
    public class SeedData
    {
        // cannot convert from 'System.IServiceProvider' to 'Microsoft.Extensions.DependencyInjection.IServiceCollection'
        // System.IServiceProvider
        // Microsoft.Extensions.DependencyInjection.IServiceCollection
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WeatherContext(
                serviceProvider.GetRequiredService<DbContextOptions<WeatherContext>>()))
            {
                if (context.Weather.Any())
                {
                    return; // DB has been seeded
                }
                context.Weather.AddRange(
                    new Weather
                    {
                        Status = "Cold",
                        Message = "It is cold outside!"
                    },
                    new Weather
                    {
                        Status = "Hot",
                        Message = "It is hot outside!"
                    },
                    new Weather
                    {
                        Status = "Humid",
                        Message = "It is humid outside!"
                    },
                    new Weather
                    {
                        Status = "Dry",
                        Message = "It is dry outside!"
                    }

                );
                context.SaveChanges();
            }
        }
    }
}
