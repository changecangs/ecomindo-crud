using Microsoft.EntityFrameworkCore;
using ecomindo_crud.Model;
using ecomindo_crud.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ecomindo_crud.BLL
{
    public class EmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Employee>> GetAllEmployeeAsync()
        {
            return await _unitOfWork.EmployeeRepository.GetAll().Include(a => a.Company).ToListAsync();
        }
        public async Task<Employee> GetEmployeeByIdAsync(Guid id)
        {
            Employee employee = null;

            employee = await _unitOfWork.EmployeeRepository.GetAll()
                    .Include(a => a.Company)
                    .FirstOrDefaultAsync(b => b.Id == id);
            return employee;
        }
        public async Task UpdateEmployeeAsync(Employee employee)
        {
            Employee employeeFromDb = await _unitOfWork.EmployeeRepository.GetSingleAsync(x => x.Id == employee.Id);
            if (employeeFromDb == null)
            {
                throw new Exception($"Author with id {employee.Id} not exist");
            }

            _unitOfWork.EmployeeRepository.Edit(employee);
            await _unitOfWork.SaveAsync();
        }
        public async Task DeleteEmployeeAsync(Guid id)
        {
            _unitOfWork.EmployeeRepository.Delete(x => x.Id == id);
            await _unitOfWork.SaveAsync();
        }
    }
}
