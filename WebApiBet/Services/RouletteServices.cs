using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiBet.DAO;
using WebApiBet.DAO.Entities;
using WebApiBet.Services.Contracts;

namespace WebApiBet.Services
{
    public class RouletteServices : IRouletteServices
    {
        private DbContext _dbContext = new DbContext();

        public IEnumerable<Roulette> GetRoulettes()
        {
            return _dbContext.GetRoulettes();
        }

        public int insertRoulette(Roulette roulette)
        {
            return _dbContext.insertRoulette(roulette);
        }

        public bool updateStateRoulette(int idRoulette)
        {
            return _dbContext.updateStateRoulette(idRoulette);
        }
    }
}
