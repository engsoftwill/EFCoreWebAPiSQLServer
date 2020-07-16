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
    public class BattleController : ControllerBase
    {
        private readonly IEFCoreRepository _repo;

        public BattleController(IEFCoreRepository repo)
        {
            _repo = repo;
        }
        // GET: api/<BattleController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var batalhas = await _repo.GetAllBattles(true);
                return Ok(batalhas);
            }
            catch (Exception ex1)
            {

                return BadRequest($"Error!: {ex1} ");
            }

        }

        
        // GET api/<BattleController>/5
        [HttpGet("{id}", Name = "GetBattle")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var heroi = await _repo.GetABattleById(id,true);
                if (heroi != null)
                    return Ok(heroi);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error!: {ex} ");
            }
            return BadRequest("Not Found");
        }
        
        // POST api/<BattleController>
        [HttpPost]
        public async Task<IActionResult> Post(Battle model)
        {
            try
            {

                _repo.Add(model);
                if (await _repo.SaveChangeAsync())
                {
                    return Ok("BAZINGA");
                }
                    

            }
            catch (Exception ex)
            {
                return BadRequest($"Error!: {ex} ");
            }
            return BadRequest("Not Saved");
        }
        
        // PUT api/<BattleController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Battle model)
        {
            try
            {
                var heroi = await _repo.GetABattleById(id);
                if (heroi != null)
                    _repo.Update(model);
                if (await _repo.SaveChangeAsync())
                {
                    return Ok("BAZINGA");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error!: {ex} ");
            }
            return BadRequest("Not Deleted");
        }

        // DELETE api/<BattleController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var heroi = await _repo.GetABattleById(id);
                if (heroi != null  )
                _repo.Delete(heroi);
                if (await _repo.SaveChangeAsync())
                {
                    return Ok("BAZINGA");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error!: {ex} ");
            }
            return BadRequest("Not Deleted");
        }
        
    }
}
