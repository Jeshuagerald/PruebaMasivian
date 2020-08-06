using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiBet.DAO.Entities;

namespace WebApiBet.Services.Contracts
{
    public interface IRouletteServices
    {
        IEnumerable<Roulette> GetRoulettes();
        int insertRoulette(Roulette roulette);
        bool updateStateRoulette(int idRoulette);
    }
}
