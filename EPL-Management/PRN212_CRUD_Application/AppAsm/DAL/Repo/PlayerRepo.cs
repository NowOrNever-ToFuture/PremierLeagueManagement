using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{

    public class PlayerRepo
    {
        private EplmanagementContext _context = new();

        public void Create(Player player)
        {
            ;
            _context.Players.Add(player);
            _context.SaveChanges();
        }

        public void Delete(Player player)
        {

            _context.Players.Remove(player);
            _context.SaveChanges();
        }

        public void Update(Player player)
        {
            using (var context = new EplmanagementContext())
            {
                var existingEntity = context.Players.FirstOrDefault(e => e.PlayerId == player.PlayerId);
                var trackedEntity = _context.ChangeTracker.Entries<Player>()
                                .FirstOrDefault(e => e.Entity.PlayerId == player.PlayerId);

                if (existingEntity != null)
                {
                    existingEntity.FullName = player.FullName;
                    existingEntity.Position = player.Position;
                    existingEntity.JerseyNumber = player.JerseyNumber;
                    existingEntity.DateOfBirth = player.DateOfBirth;
                    existingEntity.Nationality = player.Nationality;
                    if (trackedEntity != null)
                    {
                        trackedEntity.State = EntityState.Detached; // Gỡ thực thể đang được theo dõi
                    }
                    _context.Players.Update(player);
                    context.SaveChanges();  // Lưu thay đổi vào cơ sở dữ liệu
                }
                

            }
        }







        public List<Player> GetAll(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null || user.FootballTeamId == null)
                return new List<Player>(); // Không có user hoặc user không có đội bóng.

            return _context.Players.Include(p => p.FootballTeam)
                                   .Where(p => p.FootballTeamId == user.FootballTeamId)
                                   .ToList();
        }

        public string GetTeamNameByUserId(int userId)
        {

            var user = _context.Users.Find(userId);
            var teamName = _context.FootballTeams
                          .Where(ft => ft.FootballTeamId == user.FootballTeamId)
                          .Select(ft => ft.TeamName)
                          .FirstOrDefault();

            return teamName ?? "No Team";
        }

        public List<Player> GetAllPlayers()
        {

            return _context.Players.ToList();
        }


    }
}
