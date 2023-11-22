using AutoMapper;
using hikitocAPI.Data;
using hikitocAPI.Models.Domain;
using hikitocAPI.Models.DTO;
using hikitocAPI.StorageRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hikitocAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SolarSystemsController : ControllerBase {
        private readonly ISolarSystemStorageRepository solarSystemStorageRepository;
        private readonly IMapper mapper;

        public SolarSystemsController(ISolarSystemStorageRepository solarSystemStorageRepository, IMapper mapper) {
            this.solarSystemStorageRepository = solarSystemStorageRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            try {
                var solarSystems = await solarSystemStorageRepository.GetAllAsync();

                //var solarSystemsDto = solarSystems.Select(solarSystem => new SolarSystemDto() {
                //    Id = solarSystem.Id,
                //    Name = solarSystem.Name,
                //    Code = solarSystem.Code,
                //    Image = solarSystem.Image,
                //}).ToList();

                var solarSystemsDto = mapper.Map<List<SolarSystemDto>>(solarSystems);

                return Ok(new { Message = "Success from controller", Data = solarSystemsDto });
            }
            catch (DbUpdateException ex) {
                return StatusCode(500, new { Message = ex.Message.ToString() });
            }

            catch (Exception ex) {
                return StatusCode(500, new { Message = ex.Message.ToString() });
            }
        }

        [HttpGet()]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id) {
            try {
                var solarSystemSingle = await solarSystemStorageRepository.GetOneAsync(id);

                if (solarSystemSingle == null) {
                    return NotFound(new { Message = "No success from controller", });
                }

                var solarSystemDto = mapper.Map<SolarSystemDto>(solarSystemSingle);

                return Ok(new { Message = "Success from controller", Data = solarSystemDto });
            }
            catch (DbUpdateException ex) {
                return StatusCode(500, new { Message = ex.Message.ToString() });
            }

            catch (Exception ex) {
                return StatusCode(500, new { Message = ex.Message.ToString() });
            }
        }

        [HttpPost()]
        public async Task<IActionResult> InsertOne([FromBody] InsertSolarSystemDto insertSolarSystemDto) {
            try {
                var solarSystem = mapper.Map<SolarSystem>(insertSolarSystemDto);

                var InsertedSolarSystem = await solarSystemStorageRepository.InsertOneAsync(solarSystem);

                var solarSystemDto = mapper.Map<SolarSystemDto>(solarSystem);

                return Created("/api/solarsystems/" + solarSystem.Id, new { Message = "Solar system created!", Data = solarSystemDto });
            }
            catch (DbUpdateException ex) {
                return StatusCode(500, new { Message = ex.Message.ToString() });
            }

            catch (Exception ex) {
                return StatusCode(500, new { Message = ex.Message.ToString() });
            }
        }

        [HttpPut()]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateById([FromRoute] Guid id, [FromBody] UpdateSolarSystemDto updateSolarSystemDto) {
            try {
                var solarSystem = await solarSystemStorageRepository.UpdateByIdAsync(id, updateSolarSystemDto);

                var solarSystemDto = mapper.Map<SolarSystemDto>(solarSystem);

                return Ok(new { Message = "Solar system Updated!", Data = solarSystemDto });
            }

            catch (DbUpdateException ex) {
                return StatusCode(500, new { Message = ex.Message.ToString() });
            }

            catch (Exception ex) {
                return StatusCode(500, new { Message = ex.Message.ToString() });
            }
        }

        [HttpDelete()]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id) {
            try {
                var solarSystem = await solarSystemStorageRepository.DeleteByIdAsync(id);

                if (solarSystem == null) {
                    return NotFound(new { Message = "No success from controller", });
                }

                return Ok(new { Message = "Solar system Deleted!" });
            }

            catch (DbUpdateException ex) {
                return StatusCode(500, new { Message = ex.Message.ToString() });
            }

            catch (Exception ex) {
                return StatusCode(500, new { Message = ex.Message.ToString() });
            }
        }
    }
}
