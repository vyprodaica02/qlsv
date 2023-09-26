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
    public class KhoaMonController : ControllerBase
    {
        private readonly KhoaMonServices<KhoaMon> repository;
        private readonly AppDbContext _dbContext;

        public KhoaMonController(KhoaMonServices<KhoaMon> userRepository, AppDbContext dbContext)
        {
            repository = userRepository;
            this._dbContext = dbContext;
        }

        [HttpPost("AddSinhVien")]
        public async Task<IActionResult> Add(KhoaMon khoaMon)
        {
            if (khoaMon == null)
            {
                return BadRequest("lỗi");
            }
            await repository.AddAsync(khoaMon);
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
        public async Task<IActionResult> UpdateUse(KhoaMon khoaMon)
        {
            if (khoaMon == null)
            {
                return BadRequest("Lỗi");
            }
            else
            {
                await repository.UpdateAsync(khoaMon);
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
            var query = _dbContext.khoaMons.AsQueryable();

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
