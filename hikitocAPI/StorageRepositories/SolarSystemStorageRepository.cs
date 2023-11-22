using hikitocAPI.Data;
using hikitocAPI.Models.Domain;
using hikitocAPI.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hikitocAPI.StorageRepositories {
    public class SolarSystemStorageRepository : ISolarSystemStorageRepository {
        private readonly HikitocDbContext _hikitocDbContext;

        public SolarSystemStorageRepository(HikitocDbContext hikitocDbContext) {
            this._hikitocDbContext = hikitocDbContext;
        }

        public async Task<SolarSystem> DeleteByIdAsync(Guid id) {
            var solarSystemSingle = await _hikitocDbContext.SolarSystems.SingleOrDefaultAsync(item => item.Id == id);

            if (solarSystemSingle == null) {
                return null;
            }

            _hikitocDbContext.SolarSystems.Remove(solarSystemSingle);
            await _hikitocDbContext.SaveChangesAsync();

            return solarSystemSingle;
        }

        public async Task<List<SolarSystem>> GetAllAsync() {
            var solarSystems = await _hikitocDbContext.SolarSystems.ToListAsync();

            return solarSystems;
        }

        public async Task<SolarSystem> GetOneAsync(Guid id) {
            var solarSystemSingle = await _hikitocDbContext.SolarSystems.SingleOrDefaultAsync(item => item.Id == id);
            
            return solarSystemSingle;
        }

        public async Task<SolarSystem> InsertOneAsync(SolarSystem solarSystem) {
            await _hikitocDbContext.SolarSystems.AddAsync(solarSystem);
            await _hikitocDbContext.SaveChangesAsync();

            return solarSystem;
        }

        public async Task<SolarSystem> UpdateByIdAsync(Guid id, UpdateSolarSystemDto solarSystem) {
            var solarSystemSingle = await _hikitocDbContext.SolarSystems.SingleOrDefaultAsync(item => item.Id == id);

            if (solarSystemSingle == null) {
                return null;
            }

            solarSystemSingle.Name = solarSystem.Name;
            solarSystemSingle.Code = solarSystem.Code;
            solarSystemSingle.Image = solarSystem.Image;

            await _hikitocDbContext.SaveChangesAsync();

            return solarSystemSingle;
        }
    }
}
