#define COMBINED
#if COMBINED
// <snippet1>
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeMajors2026.Models;

public class CollegeMajor
{

    public int Id { get; set; }

    [StringLength(60, MinimumLength = 3)]
    public string InstituionName { get; set; } = string.Empty;

    public string InstitutionState { get; set; } = string.Empty;

    public string CipTitle { get; set; } = string.Empty;

    public int CredentialLevel { get; set; }

    public string CredentialName { get; set; } = string.Empty;

    public decimal MedianEarnings4yrUSD { get; set; }
    public decimal EarningsVsNationalPct { get; set; }
    public decimal EarningsGrowthPct1YrTo5Yr { get; set; }

}
// </snippet1>
#endif
