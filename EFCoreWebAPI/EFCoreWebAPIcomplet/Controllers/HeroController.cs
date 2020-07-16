using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Dominio;
using EFCore.Repo;
using EFCore.Repo.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCoreWebAPIcomplet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly IEFCoreRepository _repo;
        public HeroController(IEFCoreRepository repo)
        {
            _repo = repo;
        }
        // GET: api/<HeroController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var herois = await _repo.GetAllHeroes(true);
                if (herois != null)
                    return Ok( herois );
            }
            catch (Exception ex)
            {

                return BadRequest($"Error!: {ex} ");
            }
            return BadRequest("Nao ha herois");
        }

        // GET api/<HeroController>/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var heroi = await _repo.GetAHeroById(id,true);
                    if (heroi != null)
                    return Ok(heroi);
            }
            catch (Exception ex)
            {

                return BadRequest($"Error!: {ex} ");
            }
            return BadRequest("Nao ha heroi com este id");
        }

        // POST api/<HeroController>
        [HttpPost]
        public async Task<IActionResult> Post(Hero model)
        {
            try
            {
                
                _repo.Add(model);
                if (await _repo.SaveChangeAsync())
                    return Ok("BAZINGA");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error!: {ex} ");
            }
            return BadRequest("Heroi nao adicionado");
        }

        // PUT api/<HeroController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Hero model)
        {
            try
            {
                var heroi = await _repo.GetAHeroById(id, true);
                if (heroi != null)
                    _repo.Update(model);
                if(await _repo.SaveChangeAsync())
                    return Ok("BAZINGA");
                
            }
            catch (Exception ex)
            {
                return BadRequest($"Error!: {ex} ");
            }
            return BadRequest("Hero not found");
        }

        // DELETE api/<HeroController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var heroi = await _repo.GetAHeroById(id, true);
                if (heroi != null)
                {
                    _repo.Delete(heroi);
                    if (await _repo.SaveChangeAsync())
                        return Ok("BAZINGA");
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Error!: {ex} ");
            }
            return BadRequest("Hero not Deleted");
        }
    }
}
