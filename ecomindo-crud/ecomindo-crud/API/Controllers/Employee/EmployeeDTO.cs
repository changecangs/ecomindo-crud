using System;
using ecomindo_crud.API.Controllers.Company;

namespace ecomindo_crud.API.Controllers.Employee
{
    public class EmployeeDTO
    {
        public Guid? id { get; set; }
        public string Name { get; set; }
        public Guid CompanyId { get; set; }
    }
    public class EmployeeWIthCompaniesDTO : EmployeeDTO
    {
        public CompanyDTO Company { get; set; }
    } 
}
