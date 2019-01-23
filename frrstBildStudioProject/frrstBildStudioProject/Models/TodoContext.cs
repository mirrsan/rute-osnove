using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace frrstBildStudioProject.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options):base(options)
        {

        }
        public DbSet<TodoItem> TodoItems { get; set; }

        public DbSet<Korisnik> Korisnici { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var jsonString = File.ReadAllText("MOCK_DATA.json");
            var list = JsonConvert.DeserializeObject<List<Korisnik>>(jsonString);
            modelBuilder.Entity<Korisnik>().HasData(list);
        }
    }

    
}

