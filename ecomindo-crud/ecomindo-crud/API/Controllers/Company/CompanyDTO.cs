using System;
using System.Collections.Generic;
using ecomindo_crud.API.Controllers.Employee;

namespace ecomindo_crud.API.Controllers.Company
{
    public class CompanyDTO
    {
        public Guid? id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class CompanyWithEmployeeDTO : CompanyDTO
    {
        public List<EmployeeDTO> Employees { get; set; }
    }
}
