using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class TeamRepo
    {
        private EplmanagementContext _context;
        public List<FootballTeam> GetAll()
        {
            _context = new();  //viết ngắn
            return _context.FootballTeams.ToList();
        }
    }
}
