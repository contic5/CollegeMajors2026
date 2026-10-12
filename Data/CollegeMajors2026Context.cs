
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CollegeMajors2026.Models;

namespace CollegeMajors2026.Data
{
    public class CollegeMajors2026Context : DbContext
    {
        public CollegeMajors2026Context (DbContextOptions<CollegeMajors2026Context> options)
            : base(options)
        {
        }

        public DbSet<CollegeMajors2026.Models.CollegeMajor> CollegeMajor { get; set; } = default!;
    }
}