using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wallet_guardian_backend.Contracts;
using wallet_guardian_backend.Data;
using wallet_guardian_backend.Models.Kategory;

namespace wallet_guardian_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IKategoriesRepository _kategoriesRepository;


        public KategoriesController(IMapper mapper, IKategoriesRepository kategoriesRepository)
        {
            _mapper = mapper;
            _kategoriesRepository = kategoriesRepository;
        }

        // GET: api/Kategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KategoryDto>>> GetKategories()
        {
            var categories = await _kategoriesRepository.GetAllAsync();
            var records = _mapper.Map<KategoryDto>(categories);
            return Ok(records);
        }

        // GET: api/Kategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KategoryDto>> GetKategory(int id)
        {
            var kategory = await _kategoriesRepository.GetAsync(id);

            if (kategory == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<KategoryDto>(kategory));
        }

        // PUT: api/Kategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKategory(int id, KategoryDto kategoryDto)
        {
            if (id != kategoryDto.Id)
            {
                return BadRequest();
            }

            var kategory = await _kategoriesRepository.GetAsync(id);
            if (kategory == null)
            {
                return NotFound();
            }

            _mapper.Map(kategoryDto, kategory);

            try
            {
                await _kategoriesRepository.UpdateAsync(kategory);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await KategoryExists(id))
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

        // POST: api/Kategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kategory>> PostKategory(KategoryDto kategoryDto)
        {
            var kategory = _mapper.Map<Kategory>(kategoryDto);
            await _kategoriesRepository.AddAsync(kategory);

            return CreatedAtAction("GetKategory", new { id = kategory.Id }, kategory);
        }

        // DELETE: api/Kategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKategory(int id)
        {
            var kategory = await _kategoriesRepository.GetAsync(id);
            if (kategory == null)
            {
                return NotFound();
            }

            await _kategoriesRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> KategoryExists(int id)
        {
            return await _kategoriesRepository.Exists(id);
        }
    }
}