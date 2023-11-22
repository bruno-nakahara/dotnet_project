using AutoMapper;
using hikitocAPI.Models.Domain;
using hikitocAPI.Models.DTO;

namespace hikitocAPI.MappingProfiles {
    public class SolarSystemProfile : Profile {
        public SolarSystemProfile() { 
            CreateMap<SolarSystem, SolarSystemDto>().ReverseMap();
            CreateMap<InsertSolarSystemDto, SolarSystem>().ReverseMap();
        }
    }
}
