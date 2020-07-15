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
        public ActionResult Get()
        {
            try
            {
                return Ok(new Battle());
            }
            catch (Exception ex1)
            {

                return BadRequest($"Error!: {ex1} ");
            }

        }

        /*
        // GET api/<BattleController>/5
        [HttpGet("{id}", Name = "GetBattle")]
        public ActionResult Get(int id)
        {
            var battle = _context.Battles.Find(id);
            return Ok(battle);
        }
        */
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
                
                        return Ok("BAZINGA");
            
            }
            catch (Exception ex)
            {
                return BadRequest($"Error!: {ex} ");
            }
            return BadRequest("Not Saved");
        }
        /*
        // DELETE api/<BattleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {

                _repo.Delete(Re);
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
        */
    }
}
