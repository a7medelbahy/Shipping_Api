namespace TestingProject.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<Admin>? Admins { get; set; }
        public virtual List<Employee>? Employees { get; set; }
        public virtual List<Customer>? Customers { get; set; }

        public virtual List<Delivery>? Deliveries { get; set; }

    }
}
