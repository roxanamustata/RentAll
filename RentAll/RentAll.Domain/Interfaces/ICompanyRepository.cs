using System;
using System.Collections.Generic;
using System.Text;

namespace RentAll.Domain.Interfaces
{
    public interface ICompanyRepository
    {
        void Save();
        List<Company> GetCompanies();
        Company GetCompanyById(int companyId);
        void InsertCompany(Company company);
        void DeleteCompany(int companyId);
        void UpdateCompany(Company company);
    }
}
