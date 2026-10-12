using Microsoft.EntityFrameworkCore;
using CollegeMajors2026.Data;

namespace CollegeMajors2026.Models;

using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.IO;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new CollegeMajors2026Context(
            serviceProvider.GetRequiredService<
                DbContextOptions<CollegeMajors2026Context>>()))
        {
            if (context == null || context.CollegeMajor == null)
            {
                throw new ArgumentNullException("Null CollegeMajors2026Context");
            }

            // Look for any CollegeMajors.
            if (context.CollegeMajor.Any())
            {
                return;   // DB has been seeded
            }

             var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true, // Set to false if your CSV lacks headers
            };

            using var reader = new StreamReader("Data/mcu.csv");
            using var csv = new CsvReader(reader, config);
            var records = csv.GetRecords<dynamic>().ToList();

            foreach(var record in records)
            {
                Console.WriteLine(record.Title);
                context.CollegeMajor.Add(
                new CollegeMajor
                {
                    Title = record.Title,
                    ReleaseDate = DateTime.Parse(record.ReleaseDate),
                    Genre = "Test",
                    Price = 7.99M
                });
            }

            
            context.SaveChanges();
        }
    }
}