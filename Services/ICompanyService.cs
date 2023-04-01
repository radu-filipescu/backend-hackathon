using PlanetPals___backend.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services
{
    public interface ICompanyService
    {
        public List<CompanyDto> ViewCompanies();
        public CompanyDto ViewCompanyById( int id );

        public void AddCompany(CompanyDto company);
    }
}
