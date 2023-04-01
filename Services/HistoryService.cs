using backend.Configs;
using backend.Database;
using backend.DTOs;
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
            var result = _context.Actions.FirstOrDefault(action => action.actionId == id);

            return result;
        }

        public void HandleAction(HistoryDto action)
        {
            _context.Add(action);

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
        }
    }
}
