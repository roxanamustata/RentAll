using Microsoft.EntityFrameworkCore;
using RentAll.Domain;
using RentAll.Domain.Interfaces;
using RentAll.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAll.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        #region fields
        private readonly RentAllDbContext _rentAllDbContext;
        #endregion

        #region constructors
        public CompanyRepository(RentAllDbContext rentAllDbContext)
        {
            _rentAllDbContext = rentAllDbContext;
        }
        #endregion


        #region public methods


        #region CRUD company

        public async Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            try
            {
                return await _rentAllDbContext.Companies.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<Company> GetCompanyByIdAsync(int companyId)
        {
            return await _rentAllDbContext.Companies.FirstOrDefaultAsync(c => c.Id == companyId);
        }

        public async Task<Company> CreateCompanyAsync(Company company)
        {
            if (company == null)
            {
                throw new ArgumentNullException($"{nameof(CreateCompanyAsync)} entity must not be null");
            }

            try
            {
                await _rentAllDbContext.Companies.AddAsync(company);
                await _rentAllDbContext.SaveChangesAsync();

                return company;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(company)} could not be saved: {ex.Message}");
            }

        }

        public async Task UpdateCompanyAsync(Company company)
        {
            if (company == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateCompanyAsync)} entity must not be null");
            }

            try
            {
                _rentAllDbContext.Companies.Update(company);
                await _rentAllDbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(company)} could not be updated: {ex.Message}");
            }
        }

        public async Task DeleteCompanyAsync(int companyId)
        {
            var company = _rentAllDbContext.Companies.Find(companyId);


            if (company != null)
            {
                _rentAllDbContext.Companies.Remove(company);
                await _rentAllDbContext.SaveChangesAsync();
            }
        }

        #endregion

       

        #region CRUD Person


        #endregion

        





       
        #endregion
    }
}
