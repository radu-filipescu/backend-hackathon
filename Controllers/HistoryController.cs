using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _historyService;

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        // GET: api/<HistoryController>
        [HttpGet]
        public List<HistoryDto> GetAll()
        {
            var result = _historyService.GetAll();

            return result;
        }

        [HttpGet("{id}")]
        public HistoryDto Get(int id)
        {
            return _historyService.GetHistoryById(id);
        }

        [HttpGet("GetHistoryByCompanyId/{id}")]

        public List<HistoryDto> GetHistoryByCompanyId( int id)
        {
            return _historyService.GetHistoryByCompanyId(id);
        }
        // POST api/<HistoryController>
        [HttpPost]
        public HistoryDto Post([FromBody] HistoryDto action)
        {
            var result = _historyService.HandleAction(action);

            return result;
        }

        [HttpDelete("{id}")]
        public void PostDelete(int id)
        {
            _historyService.DeleteHistory(id);
        }
    }
}
