using Microsoft.EntityFrameworkCore;
using ecomindo_crud.Model;
using ecomindo_crud.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ecomindo_crud.BLL
{
    public class CompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Company>> GetAllCompanyAsync()
        {
            return await _unitOfWork.CompanyRepository.GetAll().Include(a => a.Employees).ToListAsync();
        }

        public async Task<Company> GetCompanyByIdAsync(Guid id)
        {
            Company company = await _unitOfWork.CompanyRepository.GetAll()
                    .Include(a => a.Employees)
                    .FirstOrDefaultAsync(b => b.Id == id);
            return company;
        }
        public async Task CreateCompanyAsync(Company company)
        {
            bool isExist = _unitOfWork.CompanyRepository.IsExist(x => x.Id == company.Id);
            if (isExist)
            {
                throw new Exception($"Author with email {company.Id} already exist");
            }
            await _unitOfWork.CompanyRepository.AddAsync(company);
            await _unitOfWork.SaveAsync();
        }
        public async Task UpdateCompanyAsync(Company company)
        {
            Company companyFromDb = await _unitOfWork.CompanyRepository.GetSingleAsync(x => x.Id == company.Id);
            
            if (companyFromDb == null)
            {
                throw new Exception($"Author with id {company.Id} not exist");
            }
            companyFromDb.Name = company.Name;
            companyFromDb.Description = company.Description;
            companyFromDb.DateModified = DateTime.UtcNow;

            _unitOfWork.CompanyRepository.Edit(companyFromDb);
            await _unitOfWork.SaveAsync();
        }
        public async Task DeleteCompanyAsync(Guid id)
        {
            _unitOfWork.CompanyRepository.Delete(x => x.Id == id);
            await _unitOfWork.SaveAsync();
        }
    }
}
