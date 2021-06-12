using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAll.Domain.Interfaces
{
   public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetCompaniesAsync();
        Task<Company> GetCompanyByIdAsync(int id);
        Task<Company> CreateCompanyAsync(Company company);
        Task UpdateCompanyAsync(Company company);
        Task DeleteCompanyAsync(int companyId);
    }
}
