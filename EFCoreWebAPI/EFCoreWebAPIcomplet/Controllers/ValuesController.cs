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
    public class ValuesController : ControllerBase
    {
        private readonly HeroContext _context;
        public ValuesController(HeroContext context)
        {
            _context = context;
        }
        // GET: api/<ValuesController>
        [HttpGet("filter/{name}")]
        public ActionResult Get(string name)
        {
            List<Hero> listheroes = _context.Heroes
                                    .Where(x => x.Name.Contains(name))
                                    .ToList();
            //var listheroes = (from heroi in _context.Heroes
            //                  where heroi.Name.Contains(name)
            //                  select heroi).ToList();
            return Ok(listheroes);
        }



        // GET api/<ValuesController>/5
        [HttpGet("id/{id}")]
        public ActionResult GetId(int id)
        {
            var heroi = new Hero { Name = "Thor" };
            _context.Heroes.Add(heroi); // defino de forma explicita quem estou adicionando
                //contexto.Add(heroi);
                //definindo o id estou fazendo um update, caso não coloque id ele considera um insert
            _context.SaveChanges(); 
            return Ok(); //retorna 200
        }
        

        [HttpGet("name/{Name}")]
        public ActionResult GetName(string name)
        {
            var heroi = new Hero { Name = name };
            _context.Heroes.Add(heroi); 
            _context.SaveChanges();
            return Ok(); //retorna 200
        }

        [HttpGet("update/{Name}")]
        public ActionResult Getupdt(string name)
        {
            var heroi = _context.Heroes.Where(x => x.Id == 3).FirstOrDefault();
            heroi.Name = "Hulk";
            _context.SaveChanges();
            return Ok(); //retorna 200
        }

        [HttpGet("AddRange")]
        public ActionResult Getaddrange()
        {
            _context.AddRange(
                new Hero { Name = "Captain" },
                new Hero { Name = "Spiderman" },
                new Hero { Name = "StarLord" },
                new Hero { Name = "Gamora" },
                new Hero { Name = "AntMan" },
                new Hero { Name = "MissMarvel" }
                );
            _context.SaveChanges();
            return Ok(); //retorna 200
        }






        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpGet("delete/{id}")] //gambiarra total para poder ser utilizado no browser sem Postman
        public void Delete(int id)
        {
            var heroi = (from h in _context.Heroes
                         where h.Id.Equals(id)
                         select h).Single();
            _context.Heroes.Remove(heroi);
            _context.SaveChanges();
        }
    }
}
