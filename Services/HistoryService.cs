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

        public HistoryService(AppDBContext context)
        {
            _context = context;
        }
        public List<HistoryDto> GetAll()
        {
            var result = _context.Actions.Select(action => action).ToList();

            return result;
        }

        public void HandleAction(HistoryDto action)
        {
            _context.Add(action);

            _context.SaveChanges();
        }
    }
}
