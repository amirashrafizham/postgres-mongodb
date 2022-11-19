using System;
using Microsoft.EntityFrameworkCore;
using temp_api.Models;

namespace temp_api.Data
{
    public class CharacterContext : DbContext
    {
        private readonly IConfiguration configuration;

        public CharacterContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(configuration.GetConnectionString("CharacterConnection"));
        }

        public DbSet<Character> Characters { get; set; }
    }
}
