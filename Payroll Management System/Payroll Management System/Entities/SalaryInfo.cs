using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payroll_Management_System.Entities
{
    public class SalaryInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public double Salary { get; set; }

        [Required]
        public double Tax { get; set; }


        public virtual ObservableCollection<Employee> Employees { get; private set; }
    }
}
