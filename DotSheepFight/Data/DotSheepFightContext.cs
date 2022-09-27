using DotSheepFight.Models;
using Microsoft.EntityFrameworkCore;

public class DotSheepFightContext : DbContext
    {
        public DotSheepFightContext (DbContextOptions<DotSheepFightContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = default!;
    }
