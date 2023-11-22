using hikitocAPI.Models.Domain;
using hikitocAPI.Models.DTO;

namespace hikitocAPI.StorageRepositories {
    public interface ISolarSystemStorageRepository {
        public Task<List<SolarSystem>> GetAllAsync();
        public Task<SolarSystem> GetOneAsync(Guid id);
        public Task<SolarSystem> InsertOneAsync(SolarSystem solarSystem);
        public Task<SolarSystem?> UpdateByIdAsync(Guid id, UpdateSolarSystemDto solarSystem);
        public Task<SolarSystem> DeleteByIdAsync(Guid id);
    }
}
