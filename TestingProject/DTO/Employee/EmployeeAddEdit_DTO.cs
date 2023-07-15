using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TestingProject.DTO.Employee
{
    public class EmployeeAddEdit_DTO
    {
        [RegularExpression(@"^[a-zA-Z_ ]{5,25}$", ErrorMessage = "Name Must Be Between 5 to 25 charchters")]
        public string name { get; set; }

        [RegularExpression(@"[a-zA-Z0-9]{1,20}@[a-zA-Z]{1,7}.com", ErrorMessage = "Enter valid E-Mail Address")]
        public string email { get; set; }

        [RegularExpression(@"^01[0125][0-9]{8}$", ErrorMessage = "Enter Valid Phone Number")]
        public string phone { get; set; }

        [Range(20, 60)]
        public int age { get; set; }

        [MinLength(5)]
        [MaxLength(25)]
        public string address { get; set; }

        [DefaultValue(true)]
        public bool available { get; set; }

        [MinLength(8)]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [DefaultValue(2)]
        public int? role_Id { get; set; }

        public int? branch_Id { get; set; }
    }
}
