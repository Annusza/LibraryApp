using System;
using System.Threading.Tasks;
using Library.Contract.BookDto;
using Library.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentInfoController : ControllerBase
    {
        private readonly IRentInfoService _rentInfoService;

        public RentInfoController(IRentInfoService rentInfoService)
        {
            _rentInfoService = rentInfoService;
        }

        [HttpGet("GetRentInfo/{id}")]
        public async Task<IActionResult> GetRentInfoById(long id)
        {
            try
            {
                var rentInfo = await _rentInfoService.GetById(id);
                return Ok(rentInfo);
            }
            catch (NullReferenceException e)
            {
                return NotFound(value: $"Can't found rentInfo with id = {id}");
            }
        }

        [HttpGet("GetAllRentInfos")]
        public async Task<IActionResult> GetAllRentInfos()
        {
            var rentInfos = await _rentInfoService.GetAll();
            return Ok(rentInfos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRentInfo([FromBody] RentInfoDto rentInfoDto)
        {
            if (rentInfoDto == null)
            {
                return BadRequest();
            }

            await _rentInfoService.Add(rentInfoDto);
            return Created("Created new rentInfo", rentInfoDto);
        }

        [HttpPut("UpdateRentInfo")]
        public async Task<IActionResult> UpdateRentInfo([FromBody] RentInfoDto rentInfoDto)
        {
            if (rentInfoDto == null)
            {
                return BadRequest();
            }

            await _rentInfoService.Update(rentInfoDto);
            return Ok(value: $"Updated user with id = {rentInfoDto.Id}");
        }

        [HttpDelete("DeleteRentInfo/{id}")]
        public async Task<IActionResult> DeleteRentInfo(long id)
        {
            await _rentInfoService.Delete(id);
            return Ok(value: $"RentInfo with id = {id} deleted");
        }
    }
}