using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wallet_guardian_backend.Contracts;
using wallet_guardian_backend.Data;
using wallet_guardian_backend.Models.Subcategory;

namespace wallet_guardian_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISubcategoriesRepository _subcategoriesRepository;

        public SubcategoriesController(IMapper mapper, ISubcategoriesRepository subcategoriesRepository)
        {
            _mapper = mapper;
            _subcategoriesRepository = subcategoriesRepository;
        }

        // GET: api/Subcategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubcategoryDto>>> GetSubcategories()
        {
            var subcategories = await _subcategoriesRepository.GetAllAsync();
            var records = _mapper.Map<SubcategoryDto>(subcategories);
            return Ok(records);
        }

        // GET: api/Subcategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubcategoryDto>> GetSubcategory(int id)
        {
            var subcategory = _subcategoriesRepository.GetAsync(id);

            if (subcategory == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<SubcategoryDto>(subcategory));
        }

        // PUT: api/Subcategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubcategory(int id, SubcategoryDto subcategoryDto)
        {
            if (id != subcategoryDto.Id)
            {
                return BadRequest();
            }

            var subcategory = await _subcategoriesRepository.GetAsync(id);
            if (subcategory == null)
            {
                return NotFound();
            }

            _mapper.Map(subcategoryDto, subcategory);

            try
            {
                await _subcategoriesRepository.UpdateAsync(subcategory);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await SubcategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Subcategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Subcategory>> PostSubcategory(SubcategoryDto subcategoryDto)
        {
            var subcategory = _mapper.Map<Subcategory>(subcategoryDto);
            await _subcategoriesRepository.AddAsync(subcategory);

            return CreatedAtAction("GetSubcategory", new { id = subcategory.Id }, subcategory);
        }

        // DELETE: api/Subcategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubcategory(int id)
        {
            var subcategory = await _subcategoriesRepository.GetAsync(id);
            if (subcategory == null)
            {
                return NotFound();
            }

            await _subcategoriesRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> SubcategoryExists(int id)
        {
            return await _subcategoriesRepository.Exists(id);
        }
    }
}