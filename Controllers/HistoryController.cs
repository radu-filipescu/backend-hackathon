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

        // GET: api/<HistoryController>
        [HttpGet]
        public List<HistoryDto> GetAll()
        {
            var result = _historyService.GetAll();

            return result;
        }

        // POST api/<HistoryController>
        [HttpPost]
        public void Post([FromBody] HistoryDto action)
        {
            _historyService.HandleAction(action);
        }

        // PUT api/<HistoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HistoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
