using System.ComponentModel.DataAnnotations;

namespace TestingProject.DTO.Employee
{
    public class EmployeeDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public bool available { get; set; }
        public string password { get; set; }

        public int? role_Id { get; set; }
        public int? branch_Id { get; set; }
        public string role_Name { get; set; }

        public string branch_Name { get; set; }
    }
}
