using Microsoft.EntityFrameworkCore;
using RentAll.Domain;
using RentAll.Domain.Interfaces;
using RentAll.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public List<Company> GetCompanies()
        {
            return _rentAllDbContext.Companies.ToList();
        }

        public Company GetCompanyById(int companyId)
        {
            return _rentAllDbContext.Companies.Find(companyId);
        }

        public void InsertCompany(Company company)
        {
            _rentAllDbContext.Companies.Add(company);
            Save();
        }

        public void UpdateCompany(Company company)
        {
            _rentAllDbContext.Companies.Attach(company);
            var entry = _rentAllDbContext.Entry(company);
            entry.State = EntityState.Modified;

            Save();
        }

        public void DeleteCompany(int companyId)
        {
            var company = GetCompanyById(companyId);
            _rentAllDbContext.Companies.Remove(company);
            Save();
        }

        #endregion

       

        #region CRUD Person


        #endregion

        





        public void Save()
        {
            _rentAllDbContext.SaveChanges();
        }

        #endregion
    }
}
