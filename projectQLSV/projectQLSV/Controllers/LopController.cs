using Design.Entity;
using Infrastructure.DataEx;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace projectQLSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LopController : ControllerBase
    {
        private readonly LopServices<Lop> repository;
        private readonly AppDbContext _dbContext;

        public LopController(LopServices<Lop> userRepository, AppDbContext dbContext)
        {
            repository = userRepository;
            this._dbContext = dbContext;
        }

        [HttpPost("AddSinhVien")]
        public async Task<IActionResult> Add(Lop lop)
        {
            if (lop == null)
            {
                return BadRequest("lỗi");
            }
            await repository.AddAsync(lop);
            return Ok("oke");
        }

        [HttpDelete("Delete/id")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return BadRequest("Lỗi");
            }
            else
            {
                await repository.DeleteAsync(id);
                return Ok("oke");
            }
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateUse(Lop lop)
        {
            if (lop == null)
            {
                return BadRequest("Lỗi");
            }
            else
            {
                await repository.UpdateAsync(lop);
                return Ok("oke");

            }
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var res = repository.GetAll();
            return Ok(res);
        }

        [HttpGet("getFilter")]
        public async Task<IActionResult> GetFilter(int? userId, int pageIndex, int pageSize)
        {
            var query = _dbContext.lops.AsQueryable();

            if (userId.HasValue)
            {
                query = query.Where(x => x.Id == userId);
            }

            // Không áp dụng phân trang nếu pageSize <= 0
            if (pageSize <= 0)
            {
                var filteredData = await query.ToListAsync();
                return Ok(filteredData);
            }

            // Phân trang
            int totalItems = await query.CountAsync();
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            var filteredDataWithPaging = await query.ToListAsync();

            return Ok(filteredDataWithPaging);
        }
    }
}
