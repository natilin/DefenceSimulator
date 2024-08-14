using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DefenceSimulator.Models;

namespace DefenceSimulator.Data
{
    public class DefenceSimulatorContext : DbContext
    {
        public DefenceSimulatorContext (DbContextOptions<DefenceSimulatorContext> options)
            : base(options)
        {
        }

        public DbSet<DefenceSimulator.Models.Weapon> Weapon { get; set; } = default!;
        public DbSet<DefenceSimulator.Models.DefenceWeapon> DefenceWeapon { get; set; } = default!;
        public DbSet<DefenceSimulator.Models.Enemy> Enemy { get; set; } = default!;
        public DbSet<DefenceSimulator.Models.Salvo> Salvo { get; set; } = default!;
        public DbSet<DefenceSimulator.Models.Response> Response { get; set; } = default!;
    }
}
