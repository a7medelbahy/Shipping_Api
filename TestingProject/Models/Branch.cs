using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestingProject.Models
{
    public class Branch
    {
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_ ]{3,25}$", ErrorMessage = "Name Must Be Between 3 to 25 charchters")]
        public string Name { get; set; }

        [DefaultValue(true)]

        public bool Available { get; set; }

        public virtual List<Governorate>? Governorates { get; set; }
        public virtual List<Employee>? Employees { get; set; }
        public virtual List<Customer>? Customers { get; set; }
        public virtual List<Delivery>? Deliveries { get; set; }
        public virtual List<Order>? Orders { get; set; }

    }
}
