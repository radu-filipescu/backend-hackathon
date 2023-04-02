using backend.Configs;
using backend.Database;
using backend.DTOs;
using PlanetPals___backend.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly AppDBContext _context;
        private UserActionsTable ScoreMap = new UserActionsTable();

        public HistoryService(AppDBContext context)
        {
            _context = context;
        }
        public List<HistoryDto> GetAll()
        {
            var result = _context.Actions.Select(action => action).ToList();

            return result;
        }

        public HistoryDto GetHistoryById(int id)
        {
            var result = _context.Actions.FirstOrDefault(action => action.Id == id);

            return result;
        }

        public List<HistoryDto> GetHistoryByCompanyId( int id)
        {
            var users = _context.Users.Where(user => user.CompanyId == id.ToString()).Select(user => user).ToList();
            List<HistoryDto> result = new List<HistoryDto>();
            for (int i = 0; i < users.Count; i = i + 1)
            {
                var user_id = users[i].Id;
                result.AddRange(_context.Actions.Where(action => action.UserId == user_id).Select(action => action).ToList() );
            }
            return result.OrderByDescending( action => action.Date ).ToList();
        }

        public void DeleteHistory(int id)
        {
            var historyDto = GetHistoryById(id);
            if( historyDto != null)_context.Actions.Remove(historyDto);

            _context.SaveChanges();
        }

        public HistoryDto HandleAction(HistoryDto action)
        {
            var result = _context.Add(action);

            

            if (action.actionId < 7)
            {
                var user = _context.Users.FirstOrDefault(user => user.Id == action.UserId);

                if (user.Score == null)
                    user.Score = "0";
                user.Score = (int.Parse(user.Score) + ScoreMap.actionIdScoreMappings[action.actionId]).ToString();

                var company = _context.Companies.FirstOrDefault(company => company.Id == int.Parse(user.CompanyId));

                company.Score = company.Score + ScoreMap.actionIdScoreMappings[action.actionId];

            }
            else {
                var company = _context.Companies.FirstOrDefault(company => company.Id == action.UserId);
                company.Score = company.Score + ScoreMap.actionIdScoreMappings[action.actionId];
            }

            _context.SaveChanges();

            var post = _context.Actions.FirstOrDefault(post => post.Id == result.Entity.Id);
            post.PhotoPath = post.Id.ToString();

            _context.SaveChanges();

            return result.Entity;
        }
    }
}
