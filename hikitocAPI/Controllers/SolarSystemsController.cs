//using hikitocAPI.Data;
//using hikitocAPI.Models.Domain;
//using hikitocAPI.Models.DTO;
//using hikitocAPI.StorageRepositories;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace hikitocAPI.Controllers {
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SolarSystemsController : ControllerBase {
//        private readonly HikitocDbContext hikitocDbContext;
//        private readonly ISolarSystemStorageRepository solarSystemStorageRepository;

//        public SolarSystemsController(HikitocDbContext hikitocDbContext, ISolarSystemStorageRepository solarSystemStorageRepository) {
//            this.hikitocDbContext = hikitocDbContext;
//            this.solarSystemStorageRepository = solarSystemStorageRepository;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetAll() {
//            try {
//                var solarSystems = await solarSystemStorageRepository.GetAllAsync();

//                var solarSystemsDto = solarSystems.Select(solarSystem => new SolarSystemDto() {
//                    Id = solarSystem.Id,
//                    Name = solarSystem.Name,
//                    Code = solarSystem.Code,
//                    Image = solarSystem.Image,
//                }).ToList();

//                return Ok(new { Message = "Success from controller", Data = solarSystemsDto });
//            }
//            catch (DbUpdateException ex) {
//                return StatusCode(500, new { Message = ex.Message.ToString() });
//            }

//            catch (Exception ex) {
//                return StatusCode(500, new { Message = ex.Message.ToString() });
//            }
//        }

//        [HttpGet()]
//        [Route("{id:Guid}")]
//        public async Task<IActionResult> GetById([FromRoute] Guid id) {
//            try {
//                var solarSystemSingle = await solarSystemStorageRepository.GetOneAsync(id);

//                if (solarSystemSingle == null) {
//                    return NotFound(new { Message = "No success from controller", });
//                }

//                var solarSystemDto = new SolarSystemDto() {
//                    Id = solarSystemSingle.Id,
//                    Name = solarSystemSingle.Name,
//                    Code = solarSystemSingle.Code,
//                    Image = solarSystemSingle.Image,
//                };

//                return Ok(new { Message = "Success from controller", Data = solarSystemDto });
//            }
//            catch (DbUpdateException ex) {
//                return StatusCode(500, new { Message = ex.Message.ToString() });
//            }

//            catch (Exception ex) {
//                return StatusCode(500, new { Message = ex.Message.ToString() });
//            }
//        }

//        [HttpPost()]
//        public async Task<IActionResult> InsertOne([FromBody] InsertSolarSystemDto insertSolarSystemDto) {
//            try {
//                var solarSystem = new SolarSystem() {
//                    Name = insertSolarSystemDto.Name,
//                    Code = insertSolarSystemDto.Code,
//                    Image = insertSolarSystemDto.Image,
//                };

//                var InsertedSolarSystem = await solarSystemStorageRepository.InsertOneAsync(solarSystem);

//                var solarSystemDto = new SolarSystemDto() {
//                    Id = InsertedSolarSystem.Id,
//                    Name = InsertedSolarSystem.Name,
//                    Code = InsertedSolarSystem.Code,
//                    Image = InsertedSolarSystem.Image,
//                };

//                return Created("/api/solarsystems/" + solarSystem.Id, new { Message = "Solar system created!", Data = solarSystemDto });
//            }
//            catch (DbUpdateException ex) {
//                return StatusCode(500, new { Message = ex.Message.ToString() });
//            }

//            catch (Exception ex) {
//                return StatusCode(500, new { Message = ex.Message.ToString() });
//            }
//        }

//        [HttpPut()]
//        [Route("{id:Guid}")]
//        public async Task<IActionResult> UpdateById([FromRoute] Guid id, [FromBody] UpdateSolarSystemDto updateSolarSystemDto) {
//            try {
//                var solarSystem = await solarSystemStorageRepository.UpdateByIdAsync(id, updateSolarSystemDto);

//                var solarSystemDto = new SolarSystemDto() {
//                    Id = solarSystem.Id,
//                    Name = solarSystem.Name,
//                    Code = solarSystem.Code,
//                    Image = solarSystem.Image,
//                };

//                return Ok(new { Message = "Solar system Updated!", Data = solarSystemDto });
//            }

//            catch (DbUpdateException ex) {
//                return StatusCode(500, new { Message = ex.Message.ToString() });
//            }

//            catch (Exception ex) {
//                return StatusCode(500, new { Message = ex.Message.ToString() });
//            }
//        }

//        [HttpDelete()]
//        [Route("{id:Guid}")]
//        public async Task<IActionResult> DeleteById([FromRoute] Guid id) {
//            try {
//                var solarSystem = await solarSystemStorageRepository.DeleteByIdAsync(id);

//                if (solarSystem == null) {
//                    return NotFound(new { Message = "No success from controller", });
//                }

//                return Ok(new { Message = "Solar system Deleted!" });
//            }

//            catch (DbUpdateException ex) {
//                return StatusCode(500, new { Message = ex.Message.ToString() });
//            }

//            catch (Exception ex) {
//                return StatusCode(500, new { Message = ex.Message.ToString() });
//            }
//        }
//    }
//}
