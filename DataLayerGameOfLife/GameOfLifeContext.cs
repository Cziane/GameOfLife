using DataLayerGameOfLife.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayerGameOfLife
{
    public class GameOfLifeContext :DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:dstise.database.windows.net,1433;Initial Catalog=gameoflife;Persist Security Info=False;User ID=dstise;Password=SoftwareEngineerS24;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        public DbSet<Rule> Rules { get; set; }
        public DbSet<InitialState> InitialStates { get; set; }
    }
}
