using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Dominio;
using EFCore.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                return Ok(new Hero() );
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
            try
            {
                var heroi = (from h in _context.Heroes
                             where h.Id == id
                             select h).FirstOrDefault();
                return Ok(heroi);
            }
            catch (Exception ex)
            {

                return BadRequest($"Error!: {ex} ");
            }
        }

        // POST api/<HeroController>
        [HttpPost]
        public ActionResult Post(Hero model)
        {
            try
            {
                
                _context.Heroes.Add(model);
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
        public ActionResult Put(int id, Hero model)
        {
            try
            {
                if (_context.Heroes.AsNoTracking()
                    .FirstOrDefault(x => x.Id == id) != null)
                {
                    _context.Heroes.Update(model);
                    _context.SaveChanges();
                    return Ok("BAZINGA");
                }
                return Ok("Hero not found");
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
