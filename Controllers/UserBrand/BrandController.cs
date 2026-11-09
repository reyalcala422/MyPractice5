using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPractice5.Data;
using MyPractice5.DTO.UserBrandDTO;
using MyPractice5.Model;

namespace MyPractice5.Controllers.UserBrand
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class BrandController : ControllerBase
    {
        private readonly APIDbContext _context;
        public BrandController(APIDbContext context) { 
        _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> Post(InsertBrand dto) {
            var brand = new Brand
            {
                Name = dto.Name,
            };

            _context.Brand.Add(brand);
            await _context.SaveChangesAsync();

            return Ok(new { 
            Message = "Brand Inserted!",
            Data= brand
            });
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            var brand = await _context.Brand
               .Select(x => new GetBrandDTO
               {
                   Id=x.Id, Name=x.Name
               }).ToListAsync();

            return Ok(brand);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateBrandDTO dto) {
            var brand = await _context.Brand.FindAsync(id);

            if (brand == null)
                return NotFound("Not Found!");

            var updateBrand = new
            {
                Name = dto.Name
            };

            brand.Name = dto.Name;
            await _context.SaveChangesAsync();
            return Ok(new {
            Message="Brand Updated!",
            Data= updateBrand
            });
        }
    }
}
