using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Dominio;
using EFCore.Repo;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCoreWebAPIcomplet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly HeroContext _context;

        public HeroController(HeroContext context)
        {
            _context = context;
        }
        // GET: api/<HeroController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok("BAZINGA");
            }
            catch (Exception ex)
            {

                return BadRequest($"Error!: {ex} ");
            }
            
        }

        // GET api/<HeroController>/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id)
        {
            return Ok("value");
        }

        // POST api/<HeroController>
        [HttpPost]
        public ActionResult Post(Hero value)
        {
            try
            {
                var heroi = new Hero
                {
                    Name = "IronMan",
                    Weapons = new List<Weapon>
                    {
                        new Weapon { Name = "Mark 3" },
                        new Weapon { Name = "Mark 3" }
                    }
                };
                _context.Heroes.Add(heroi);
                _context.SaveChanges();
                return Ok("BAZINGA");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error!: {ex} ");
            }
        }

        // PUT api/<HeroController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id)
        {
            try
            {
                var heroi = new Hero
                {
                    Id = id,
                    Name = "IronMan",
                    Weapons = new List<Weapon>
                    {
                        new Weapon { Name = "Mark 3" },
                        new Weapon { Name = "Mark 5" }
                    }
                };
                _context.Heroes.Update(heroi);
                _context.SaveChanges();
                return Ok("BAZINGA");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error!: {ex} ");
            }
        }

        // DELETE api/<HeroController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
