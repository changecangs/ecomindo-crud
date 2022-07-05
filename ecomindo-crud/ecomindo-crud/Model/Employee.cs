using System;
using System.Collections.Generic;

namespace ecomindo_crud.Model
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateDeleted { get; set; }


        public Employee()
        {
            DateCreated = DateTime.UtcNow;
        }

    }
}
