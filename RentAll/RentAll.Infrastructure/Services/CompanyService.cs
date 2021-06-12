using RentAll.Domain;
using RentAll.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAll.Infrastructure.Services
{
    public class CompanyService : ICompanyService
    {

        #region fields
        private readonly ICompanyRepository _companyRepository;
        #endregion

        #region constructors
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        #endregion
        #region public methods
        public async Task<Company> CreateCompanyAsync(Company company)
        {
            return await _companyRepository.CreateCompanyAsync(company);
        }

        public async Task DeleteCompanyAsync(int companyId)
        {
            await _companyRepository.DeleteCompanyAsync(companyId);
        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            return await _companyRepository.GetCompaniesAsync();
        }

        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            return await _companyRepository.GetCompanyByIdAsync(id);
        }

        public async Task UpdateCompanyAsync(Company company)
        {
            await _companyRepository.UpdateCompanyAsync(company);
        }
        #endregion

      
    }
}
