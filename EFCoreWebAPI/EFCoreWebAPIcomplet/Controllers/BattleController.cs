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
    public class BattleController : ControllerBase
    {
        private readonly HeroContext _context;

        public BattleController(HeroContext context)
        {
            _context = context;
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


        // GET api/<BattleController>/5
        [HttpGet("{id}", Name = "GetBattle")]
        public ActionResult Get(int id)
        {
            var battle = _context.Battles.Find(id);
            return Ok(battle);
        }

        
    }
}
