using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecomindo_crud.Model
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [ForeignKey("FK_Company")]
        public Guid CompanyId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        //public DateTime DateDeleted { get; set; }

        public Company Company { get; set; }
        public Employee()
        {
            DateCreated = DateTime.UtcNow;
        }

    }
}
