using DAL.Entities;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class TeamService
    {
        private TeamRepo _repo = new();

        public List<FootballTeam> GetAllNCC()
        {
            return _repo.GetAll();
        }
    }
}
