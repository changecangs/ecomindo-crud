using System;
using System.Collections.Generic;

namespace ecomindo_crud.Model
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateDeleted { get; set; }
        public Company()
        {
            DateCreated = DateTime.UtcNow;
        }
        public List<Employee> employees { get; set; }
    }
}
