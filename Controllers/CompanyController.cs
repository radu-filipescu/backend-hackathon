using backend.Services;
using Microsoft.AspNetCore.Mvc;
using PlanetPals___backend.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        // GET: api/<CompanyController>
        [HttpGet]
        public IEnumerable<CompanyDto> GetAllCompanies()
        {
            return _companyService.ViewCompanies();
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public CompanyDto Get(int id)
        {
            return _companyService.ViewCompanyById(id);
        }

        // POST api/<CompanyController>
        [HttpPost]
        public void Post([FromBody] CompanyDto company)
        {
            _companyService.AddCompany(company)
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
