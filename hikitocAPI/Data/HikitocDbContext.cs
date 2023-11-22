using hikitocAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace hikitocAPI.Data {
    public class HikitocDbContext : DbContext {

        public HikitocDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) {

        }

        public DbSet<Planet> Planets { get; set; }
        public DbSet<SolarSystem> SolarSystems { get; set; }
        public DbSet<Water> Waters { get; set; }

        //protected override void onmodelcreating(modelbuilder modelbuilder) {
        //    base.onmodelcreating(modelbuilder);
        //    modelbuilder.entity<planet>().totable("planets");
        //    modelbuilder.entity<solarsystem>().totable("solarsystems");
        //    modelbuilder.entity<water>().totable("waters");
        //}
    }
}
