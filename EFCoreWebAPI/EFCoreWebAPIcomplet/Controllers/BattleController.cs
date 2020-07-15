﻿using System;
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


        // PUT api/<BattleController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Battle model)
        {
            try
            {
                if (_context.Battles.AsNoTracking()
                    .FirstOrDefault(x => x.Id == id) != null)
                {
                    _context.Battles.Update(model);
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

        // DELETE api/<BattleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}