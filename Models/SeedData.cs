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

            using var reader = new StreamReader("Data/college_majors_2026.csv");
            using var csv = new CsvReader(reader, config);
            var records = csv.GetRecords<dynamic>().ToList();

            int id=1;
            foreach(var record in records)
            {
                int credential_level=0;
                if(record.credential_level!="")
                {
                    credential_level=int.Parse(record.credential_level);
                }

                decimal median_earnings_4yr_usd=0;
                if(record.median_earnings_4yr_usd!="")
                {
                    median_earnings_4yr_usd=decimal.Parse(record.median_earnings_4yr_usd);
                }

                decimal earnings_vs_national_pct=0;
                if(record.earnings_vs_national_pct!="")
                {
                    earnings_vs_national_pct=decimal.Parse(record.earnings_vs_national_pct);
                }

                decimal earnings_growth_pct_1yr_to_5yr=0;
                if(record.earnings_growth_pct_1yr_to_5yr!="")
                {
                    earnings_growth_pct_1yr_to_5yr=decimal.Parse(record.earnings_growth_pct_1yr_to_5yr);
                }

                context.CollegeMajor.Add(
                new CollegeMajor
                {
                    Id=id,
                    InstituionName = record.institution_name,
                    InstitutionState = record.institution_state,
                    CipTitle = record.cip_title,
                    CredentialLevel = credential_level,
                    CredentialName = record.credential_name,
                    MedianEarnings4yrUSD=median_earnings_4yr_usd,
                    EarningsVsNationalPct=earnings_vs_national_pct,
                    EarningsGrowthPct1YrTo5Yr=earnings_growth_pct_1yr_to_5yr
                });
                id+=1;
            }

            
            context.SaveChanges();
        }
    }
}