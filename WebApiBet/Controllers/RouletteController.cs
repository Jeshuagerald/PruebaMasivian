using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiBet.DAO.Entities;
using WebApiBet.Services.Contracts;

namespace WebApiBet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private readonly IRouletteServices _rouletteService;

        public RouletteController(IRouletteServices rouletteService)
        {
            _rouletteService = rouletteService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Roulette>> Get()
        {
            try
            {
                return _rouletteService.GetRoulettes().ToList();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] Roulette roulette)
        {
            try
            {
                return _rouletteService.insertRoulette(roulette);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [HttpPut("{idRoulette}")]
        public ActionResult<bool> Put(int idRoulette)
        {
            try
            {
                return _rouletteService.updateStateRoulette(idRoulette);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        // DELETE api/<RouletteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
