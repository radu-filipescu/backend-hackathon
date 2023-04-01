using backend.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services
{
    public interface IHistoryService
    {
        public List<HistoryDto> GetAll();

        public HistoryDto GetHistoryById(int id);

        public List<HistoryDto> GetHistoryByCompanyId(int id);

        public void HandleAction(HistoryDto action);
    }
}
