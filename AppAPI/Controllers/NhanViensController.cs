using AppAPI.Services;
using AppAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanViensController : ControllerBase
    {
        private readonly INVService _nVService;
        public NhanViensController(INVService nVService) 
        {
            _nVService = nVService;
        }

        [HttpGet("GetAll")]
        public async Task<List<NhanVienVM>> GetAll() 
        { 
            return await _nVService.GetAll();
        }
        [HttpGet("nhanvien/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var nV = await _nVService.GetByID(id);
            if (nV == null)
            {
                return BadRequest("Can't find capbac");
            }
            return Ok(nV);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NhanVienVM nv)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var check = await _nVService.Create(nv);
            if (check == false)
                     return BadRequest();
            
            return Ok();
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id ,[FromBody] NhanVienVM nv)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var affectedResult = await _nVService.Update(nv);
            if (affectedResult == false)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var affectedResult = await _nVService.Delete(id);
            if (affectedResult == false)
                return BadRequest();
            return Ok();
        }
        [HttpGet("BMI")]
        public IActionResult BMI(int height, int weight)
        {
            float BMI = (float)(weight) / (float)(height*height);
            return Ok(BMI);
        }
    }
}
