using DAL;
using DAL.Entities;
using DAL.Repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class PlayerService
    {
        private EplmanagementContext _context = new();
        private PlayerRepo _repo = new();

        public void CreatePlayer(Player player) => _repo.Create(player);

        public void DeletePlayer(Player player) => _repo.Delete(player);

        public void UpdatePlayer(Player player) => _repo.Update(player);

        public List<Player> GetAllPlayers(int userId) => _repo.GetAll(userId);

        public string GetTeamNameByUserId(int userId) => _repo.GetTeamNameByUserId(userId);

        public bool IsJerseyNumberDuplicate(int jerseyNumber, int userId, int? currentPlayerId = null)
        {
            // Lấy tất cả cầu thủ và kiểm tra trùng lặp số áo
            return _repo.GetAll(userId)
                        .Any(p => p.JerseyNumber == jerseyNumber &&
                                  (!currentPlayerId.HasValue || p.PlayerId != currentPlayerId));
        }



        public int? GetFootballTeamIdByUserId(int loggedInUserId)
        {
            return _context.Users
                  .Where(team => team.UserId == loggedInUserId)
                  .Select(team => team.FootballTeamId)
                  .FirstOrDefault();
        }

        public Player GetPlayerById(int playerId)
        {
            return _context.Players.AsNoTracking().FirstOrDefault(p => p.PlayerId == playerId);
        }
    }

    

}
